using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Options : MonoBehaviour
{
    public UnityAction<int> OnOptionClicked;
    public UI_OptionBtn[] Btns;

    public void SetUpOptions(Options options)
    {
        gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        foreach (var Btn in Btns)
        {
            Btn.gameObject.SetActive(false);
        }

        for (int i = 0; i < options.OptionDatas.Count; i++)
        {
            Btns[i].gameObject.SetActive(true);
            Btns[i].SetOption(
                options.OptionDatas[i].OptionContent, 
                options.OptionDatas[i].OptionAvailable);
        }
    }
}

[System.Serializable]
public class Options
{
    public List<OptionData> OptionDatas;
}

[System.Serializable]
public class OptionData
{
    public string OptionContent;
    public bool OptionAvailable;
}