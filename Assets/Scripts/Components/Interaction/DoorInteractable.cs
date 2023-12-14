using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : StaticInteractable
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            IconGroup.gameObject.SetActive(true);
            UIMgr.Instance.CenterPoint.gameObject.SetActive(true);
            UIMgr.Instance.ConfirmPanel.SetActive(false);
            GameManager.Instance.Input.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Y))
        {
            UIMgr.Instance.ConfirmPanel.SetActive(false);
            Level1Mode.Instance.StartSettle();
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        if(IsPlayerInRange)
        {
            IconGroup.gameObject.SetActive(false);
            UIMgr.Instance.CenterPoint.gameObject.SetActive(false);
            UIMgr.Instance.ConfirmPanel.SetActive(true);
            GameManager.Instance.Input.enabled = false;
        }
    }
}
