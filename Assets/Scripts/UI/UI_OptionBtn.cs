using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OptionBtn : MonoBehaviour
{
    public int OptionIndex;
    public GameObject LockObj;
    public Button m_OptionBtn;
    public Text m_OptionText;
    public UI_Options Options;

    public void SetOption(string content, bool isValid)
    {
        SetText(content);
        SetOptionValid(isValid);
    }

    public void SetText(string content)
    {
        m_OptionText.text = content;
    }

    public void SetOptionValid(bool isValid)
    {
        if (isValid)
        {
            m_OptionBtn.interactable = true;
            LockObj.SetActive(false);
        }
        else
        {
            m_OptionBtn.interactable = false;
            LockObj.SetActive(true);
        }
    }
    
    public void OnClickOption()
    {
        Options.OnOptionClicked?.Invoke(OptionIndex);
    }
}
