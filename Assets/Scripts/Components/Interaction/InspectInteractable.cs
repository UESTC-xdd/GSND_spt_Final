using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectInteractable : IInteractable
{
    public Transform RealTrans;
    public bool IsInspecting;

    public Vector3 InspectLocalPos;
    public Vector3 InspectLocalRot;

    public DialogueLine DialogLine;
    public DialogType CurDialogType;

    public UnityEvent OnBeginInteract;
    public UnityEvent OnEndInteract;

    [Header("Reference")]
    public Collider ObjCol;

    public override void OnInteract()
    {
        base.OnInteract();

        if (!IsInspecting)
        {
            Debug.Log("Inspect");

            Interactable = false;
            GameManager.Instance.PlayerInteractor.InspectObj(RealTrans, InspectLocalPos, InspectLocalRot);

            if (DialogLine.sentence != string.Empty)
            {
                UIMgr.Instance.DialogC.StartDialogue(DialogLine, CurDialogType);
            }

            OnBeginInteract?.Invoke();

            EventMgr.OnInteract -= OnEBtn;
            EventMgr.OnInteract += OnEBtn;

            IsInspecting = true;
            ObjCol.enabled = false;
        }
        else
        {
            OnEBtn();
        }
    }

    private void OnEBtn()
    {
        OnEndInteract?.Invoke();

        //if(UIMgr.IsValid)
        //{
        //    UIMgr.Instance.DialogC.StopDialog();
        //}

        GameManager.Instance.PlayerInteractor.ReturnInspectObj();
        EventMgr.OnInteract -= OnEBtn;
        Interactable = true;
        IsInspecting = false;
        ObjCol.enabled = true;
    }
}
