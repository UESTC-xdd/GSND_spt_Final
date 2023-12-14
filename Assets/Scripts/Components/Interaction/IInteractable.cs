using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IInteractable : MonoBehaviour
{
    public bool Interactable;
    public bool InteractOnce;
    public UnityEvent InteractEvt;
    public UnityEvent OnPlayerTriggerEnterEvt;
    public UnityEvent OnPlayerTriggerExitEvt;

    public bool CanInteract { get; set; }
    public bool IsPlayerInRange { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            IsPlayerInRange = true;
            OnPlayerEnterTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            IsPlayerInRange = false;
            OnPlayerExitTrigger();
        }
    }

    public virtual void OnInteract()
    {
        Debug.Log("Interact: " + gameObject.name);
        InteractEvt?.Invoke();
        if (InteractOnce)
        {
            Interactable = false;
            IsPlayerInRange = false;
        }
    }

    protected virtual void OnPlayerEnterTrigger()
    {
        OnPlayerTriggerEnterEvt?.Invoke();
    }

    protected virtual void OnPlayerExitTrigger()
    {
        OnPlayerTriggerExitEvt?.Invoke();
    }
}
