using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CenterPoint : MonoBehaviour
{
    public int PointSizze;
    public Sprite PointSprite;
    public int HandSize;
    public Sprite HandSprite;

    [Header("Reference")]
    public Image m_Img;
    public RectTransform m_RectTrans;

    public void SetHandEnabled(bool enabled)
    {
        if(enabled)
        {
            m_Img.sprite = HandSprite;
            m_RectTrans.sizeDelta = new Vector2(HandSize, HandSize);
        }
        else
        {
            m_Img.sprite = PointSprite;
            m_RectTrans.sizeDelta = new Vector2(PointSizze, PointSizze);
        }
    }


}
