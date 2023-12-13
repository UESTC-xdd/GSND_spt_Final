using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteAlways]
public class UI_SyncSize : MonoBehaviour
{
    public bool SyncHorizontal;
    public bool SyncVertical;
    public Vector2 Padding;
    public RectTransform TargetTrans;

    [SerializeField]
    private RectTransform m_RectTransform;

    private void Awake()
    {
        if(m_RectTransform == null)
        {
            m_RectTransform = GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        UpdateSize();
    }

    private void UpdateSize()
    {
        if(SyncHorizontal)
        {
            m_RectTransform.sizeDelta = new Vector2(Padding.x + TargetTrans.sizeDelta.x, m_RectTransform.sizeDelta.x);
        }

        if(SyncVertical)
        {

            m_RectTransform.sizeDelta = new Vector2(m_RectTransform.sizeDelta.x, Padding.y + TargetTrans.sizeDelta.y);
        }
    }
}
