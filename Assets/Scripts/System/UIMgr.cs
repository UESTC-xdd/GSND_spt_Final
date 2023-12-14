using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public GameObject[] Controls;

    public UI_BG BG;
    public UI_MovieBG MovieBG;
    public UI_CenterPoint CenterPoint;
    public DialogueController DialogC;
    public UI_Options Options;
    public GameObject ConfirmPanel;
    public UI_Ending Ending;

    private void Start()
    {
        GameManager.Instance.OnEnterModeAction -= OnEnterMode;
        GameManager.Instance.OnEnterModeAction += OnEnterMode;
    }

    private void OnEnterMode(GameMode toMode)
    {
        if(toMode == GameMode.MOVIE)
        {
            EnterMovieMode();
        }
        else
        {
            LeaveMovieMode();
        }
    }

    //public void UpdateProgressBar(float value,bool enabled)
    //{
    //    if(enabled)
    //    {
    //        ProgressBar.gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        ProgressBar.gameObject.SetActive(false);
    //    }
    //    ProgressBar.UpdateValue(value);
    //}

    public void EnterMovieMode()
    {
        MovieBG.ShowBG(1);
        foreach (var control in Controls)
        {
            control.SetActive(false);
        }
    }

    public void LeaveMovieMode()
    {
        MovieBG.HideBG(1);
        foreach (var control in Controls)
        {
            control.SetActive(true);
        }
    }

    public void EnterOptions()
    {
        Options.gameObject.SetActive(true);
        CenterPoint.gameObject.SetActive(false);
    }

    public void QuitOptions()
    {
        Options.gameObject.SetActive(false);
        CenterPoint.gameObject.SetActive(true);
    }

    public void Credit()
    {
        UIMgr.Instance.gameObject.SetActive(false);
        Level1Mode.Instance.CreditsScene();
    }
}
