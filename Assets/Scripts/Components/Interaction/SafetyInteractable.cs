using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyInteractable : StaticInteractable
{
    public float WaitOpenTime;
    public AudioClip OpenClip;

    [Header("Reference")]
    public Animator m_Anim;
    public AudioSource m_Source;

    private int Anim_Open;

    private void Awake()
    {
        Anim_Open = Animator.StringToHash("Open");
    }

    public void OpenSafety()
    {
        StartCoroutine(OpenSafetyCou());
    }

    private IEnumerator OpenSafetyCou()
    {
        GameManager.Instance.Input.enabled = false;
        m_Source.PlayOneShot(OpenClip);
        yield return new WaitForSeconds(WaitOpenTime);

        IconGroup.gameObject.SetActive(false);
        GameManager.Instance.Input.enabled = true;
        m_Anim.SetTrigger(Anim_Open);
        Level1Mode.Instance.OpenedSafety = true;
    }
}
