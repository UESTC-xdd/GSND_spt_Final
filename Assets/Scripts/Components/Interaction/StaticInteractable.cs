using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StaticInteractable : IInteractable
{
    public CanvasGroup ExitGroup;

    private Tween m_GroupTween;

    protected override void OnPlayerEnterTrigger()
    {
        base.OnPlayerEnterTrigger();

        if (m_GroupTween!=null)
        {
            m_GroupTween.Kill();
        }
        ExitGroup.alpha = 0;
        m_GroupTween = ExitGroup.DOFade(1, 0.5f);
    }

    protected override void OnPlayerExitTrigger()
    {
        base.OnPlayerExitTrigger();

        if(m_GroupTween != null)
        {
            m_GroupTween.Kill();
        }
        ExitGroup.alpha = 1;
        m_GroupTween = ExitGroup.DOFade(0, 0.5f);
    }

    public override void OnInteract()
    {
        base.OnInteract();
        if(IsPlayerInRange)
        {

        }
    }
}
