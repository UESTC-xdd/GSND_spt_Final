using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StaticInteractable : IInteractable
{
    public CanvasGroup IconGroup;

    private Tween m_GroupTween;

    protected override void OnPlayerEnterTrigger()
    {
        base.OnPlayerEnterTrigger();

        if(IconGroup)
        {
            if (m_GroupTween != null)
            {
                m_GroupTween.Kill();
            }
            IconGroup.alpha = 0;
            m_GroupTween = IconGroup.DOFade(1, 0.5f);
        }
    }

    protected override void OnPlayerExitTrigger()
    {
        base.OnPlayerExitTrigger();

        if (IconGroup)
        {   
            if (m_GroupTween != null)
            {
                m_GroupTween.Kill();
            }
            IconGroup.alpha = 1;
            m_GroupTween = IconGroup.DOFade(0, 0.5f);
        }
    }
}
