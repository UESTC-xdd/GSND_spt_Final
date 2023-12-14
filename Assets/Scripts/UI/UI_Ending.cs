using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Ending : MonoBehaviour
{
    public Sprite[] EndingBGImgs;
    public GameObject[] Endings;

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
            BGImg.sprite = EndingBGImgs[index];
            gameObject.SetActive(true);
            //Endings[index].gameObject.SetActive(true);
            Group.alpha = 0;
            Group.DOFade(1, 1);
        }
    }
}
