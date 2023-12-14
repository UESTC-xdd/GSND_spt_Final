using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Ending : MonoBehaviour
{
    public Sprite[] EndingBGImgs;
    public GameObject[] Endings;

    public Sprite[] WinImgs;
    public float WaitTime;
    private int WinIndex;
    private Tween m_FadeTween;

    public Image BGImg;
    public CanvasGroup Group;

    public void ShowEnding(int index)
    {
        if (index != 4)
        {
            BGImg.sprite = EndingBGImgs[index];
            gameObject.SetActive(true);
            Endings[index].gameObject.SetActive(true);
            Group.alpha = 0;
            Group.DOFade(1, 1);
        }
        else
        {
            BGImg.sprite = WinImgs[WinIndex];
            gameObject.SetActive(true);

            Group.alpha = 0;
            Group.DOFade(1, 1);

            StartCoroutine(WinSlidesCou());
        }
    }

    private IEnumerator WinSlidesCou()
    {
        yield return new WaitForSeconds(WaitTime);
        m_FadeTween = Group.DOFade(0, 1);
        yield return m_FadeTween.WaitForCompletion();

        WinIndex++;
        BGImg.sprite = WinImgs[WinIndex];
        m_FadeTween = Group.DOFade(1, 1);
        yield return new WaitForSeconds(WaitTime);
        m_FadeTween = Group.DOFade(0, 1);
        yield return m_FadeTween.WaitForCompletion();

        WinIndex++;
        BGImg.sprite = WinImgs[WinIndex];
        m_FadeTween = Group.DOFade(1, 1);
        yield return new WaitForSeconds(WaitTime);
        m_FadeTween = Group.DOFade(0, 1);
        yield return m_FadeTween.WaitForCompletion();

        Endings[4].gameObject.SetActive(true);
        m_FadeTween = Group.DOFade(1, 1);
        yield return new WaitForSeconds(WaitTime);
    }
}
