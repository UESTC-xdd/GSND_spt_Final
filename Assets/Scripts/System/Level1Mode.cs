using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Level1Mode : LevelSingleton<Level1Mode>
{
    public float RewindTime;

    [Header("Inspect1")]
    public TimelineAsset TLAsset1;
    public GameObject[] TLAsset1NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset1NeedToHideAfterRewindObjs;

    [Header("OptionSetUp")]
    public List<Options> CallingOptions = new List<Options>();
    private int CurOptionsIndex = 0;

    [Header("Reference")]
    public PlayableDirector m_Director;

    private GameObject[] CurNeedToHideBeforeRewindObjs;
    private GameObject[] CurNeedToHideAfterRewindObjs;

    private int CurRewindIndex = 0;

    private void Start()
    {
        QuestMgr.Instance.OnQuestFinished -= OnQuestFinish;
        QuestMgr.Instance.OnQuestFinished += OnQuestFinish;

        UIMgr.Instance.EnterOptions();
        UIMgr.Instance.Options.SetUpOptions(CallingOptions[CurOptionsIndex]);
        CurOptionsIndex++;
        UIMgr.Instance.Options.OnOptionClicked -= OnGetOption;
        UIMgr.Instance.Options.OnOptionClicked += OnGetOption;
    }

    private void OnQuestFinish(Quest finishedQuest)
    {
        switch (finishedQuest.QuestName)
        {
            case "Inspect1":
                {
                    OnStartDialog(TLAsset1, TLAsset1NeedToHideBeforeRewindObjs, TLAsset1NeedToHideAfterRewindObjs);
                    break;
                }
            default:
                break;
        }
    }

    public void OnStartDialog(TimelineAsset timelineAsset, GameObject[] NeedToHideBeforeRewindObjs, GameObject[] NeedToHideAfterRewindObjs)
    {
        CurNeedToHideBeforeRewindObjs = NeedToHideBeforeRewindObjs;
        CurNeedToHideAfterRewindObjs = NeedToHideAfterRewindObjs;
        m_Director.playableAsset = timelineAsset;
        StartCoroutine(StartDialogCou());
    }

    public IEnumerator StartDialogCou()
    {
        UIMgr.Instance.BG.FadeIn(2, Color.black);
        yield return new WaitUntil(() => UIMgr.Instance.BG.IsDone);

        foreach (var obj in CurNeedToHideBeforeRewindObjs)
        {
            obj.SetActive(false);
        }

        m_Director.Play();
    }

    public void OnStopDialog()
    {
        UIMgr.Instance.BG.FadeOut(0);
        StartCoroutine(RewindCou());
    }

    public IEnumerator RewindCou()
    {
        yield return new WaitForSeconds(RewindTime);
        UIMgr.Instance.BG.FadeIn(3, Color.black);
        yield return new WaitUntil(() => UIMgr.Instance.BG.IsDone);

        foreach (var gameObj in CurNeedToHideAfterRewindObjs)
        {
            gameObj.SetActive(false);
        }
        foreach (var obj in CurNeedToHideBeforeRewindObjs)
        {
            obj.SetActive(true);
        }

        UIMgr.Instance.BG.FadeOut(0);
        OnFinishRewind();
    }

    public void OnFinishRewind()
    {
        switch (CurRewindIndex)
        {
            case 0:
                {
                    
                    break;
                }
            case 1:
                {
                    
                    break;
                }
            default:
                break;
        }

        CurRewindIndex++;
    }

    private void OnGetOption(int optionIndex)
    {
        switch (CurOptionsIndex)
        {
            //Which Options
            case 1:
                {
                    //Judge options
                    switch (optionIndex)
                    {
                        case 0:
                            {
                                UIMgr.Instance.Options.SetUpOptions(CallingOptions[CurOptionsIndex]);
                                CurOptionsIndex++;
                                break;
                            }
                        case 1:
                            {
                                UIMgr.Instance.QuitOptions();
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                }
            case 2:
                {
                    switch (optionIndex)
                    {
                        case 0:
                            {
                                Debug.Log("Win");
                                UIMgr.Instance.QuitOptions();
                                break;
                            }
                        case 1:
                            {
                                UIMgr.Instance.QuitOptions();
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                }
            default:
                break;
        }

        Debug.Log("Chosed " + optionIndex);
    }
}
