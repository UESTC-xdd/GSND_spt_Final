using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Level1Mode : LevelSingleton<Level1Mode>
{
    public float RewindTime;

    [Header("Settle Audio")]
    public AudioClip BeginCallClip;
    public AudioClip EndCallClip;

    [Header("Ambient Sound")]
    public AudioSource[] AmbientSources;

    [Header("InteractableObjects")]
    public InspectInteractable[] InteractableObjects;

    [Header("Inspect1")]
    public TimelineAsset TLAsset1;
    public GameObject[] TLAsset1NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset1NeedToHideAfterRewindObjs;
    private bool Q1Finish;

    public TimelineAsset TLAsset2;
    public GameObject[] TLAsset2NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset2NeedToHideAfterRewindObjs;
    private bool Q2Finish;

    public TimelineAsset TLAsset3;
    public GameObject[] TLAsset3NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset3NeedToHideAfterRewindObjs;
    private bool Q3Finish;

    public TimelineAsset TLAsset4;
    public GameObject[] TLAsset4NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset4NeedToHideAfterRewindObjs;
    private bool Q4Finish;

    public TimelineAsset TLAsset5;
    public GameObject[] TLAsset5NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset5NeedToHideAfterRewindObjs;
    private bool Q5Finish;

    public TimelineAsset TLAsset6;
    public GameObject[] TLAsset6NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset6NeedToHideAfterRewindObjs;
    private bool Q6Finish;

    public TimelineAsset TLAsset7;
    public GameObject[] TLAsset7NeedToHideBeforeRewindObjs;
    public GameObject[] TLAsset7NeedToHideAfterRewindObjs;
    private bool Q7Finish;

    [Header("OptionSetUp")]
    public List<Options> CallingOptions = new List<Options>();
    private int CurOptionsIndex = 0;

    [Header("Reference")]
    public PlayableDirector m_Director;
    public AudioSource m_Source;

    private GameObject[] CurNeedToHideBeforeRewindObjs;
    private GameObject[] CurNeedToHideAfterRewindObjs;

    private int CurRewindIndex = 0;

    private void Start()
    {
        QuestMgr.Instance.OnQuestFinished -= OnQuestFinish;
        QuestMgr.Instance.OnQuestFinished += OnQuestFinish;

        UIMgr.Instance.Options.OnOptionClicked -= OnGetOption;
        UIMgr.Instance.Options.OnOptionClicked += OnGetOption;
    }

    public void EnableAllInteractable()
    {
        foreach (var inter in InteractableObjects)
        {
            inter.Interactable = true;
        }
    }

    public void DisableAllInteractable()
    {
        foreach (var inter in InteractableObjects)
        {
            inter.Interactable = false;
        }
    }

    public void PauseAmbientSound()
    {
        foreach (var source in AmbientSources)
        {
            source.Pause();
        }
    }

    public void PlayAmbientSound()
    {
        foreach (var source in AmbientSources)
        {
            source.Play();
        }
    }

    private void OnQuestFinish(Quest finishedQuest)
    {
        switch (finishedQuest.QuestName)
        {
            case "Inspect1":
                {
                    Q1Finish = true;
                    OnStartDialog(TLAsset1, TLAsset1NeedToHideBeforeRewindObjs, TLAsset1NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect2":
                {
                    Q2Finish = true;
                    OnStartDialog(TLAsset2, TLAsset2NeedToHideBeforeRewindObjs, TLAsset2NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect3":
                {
                    Q3Finish = true;
                    OnStartDialog(TLAsset3, TLAsset3NeedToHideBeforeRewindObjs, TLAsset3NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect4":
                {
                    Q4Finish = true;
                    OnStartDialog(TLAsset4, TLAsset4NeedToHideBeforeRewindObjs, TLAsset4NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect5":
                {
                    Q5Finish = true;
                    OnStartDialog(TLAsset5, TLAsset5NeedToHideBeforeRewindObjs, TLAsset5NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect6":
                {
                    Q6Finish = true;
                    OnStartDialog(TLAsset6, TLAsset6NeedToHideBeforeRewindObjs, TLAsset6NeedToHideAfterRewindObjs);
                    break;
                }
            case "Inspect7":
                {
                    Q7Finish = true;
                    OnStartDialog(TLAsset7, TLAsset7NeedToHideBeforeRewindObjs, TLAsset7NeedToHideAfterRewindObjs);
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

        DisableAllInteractable();
        StartCoroutine(StartDialogCou());
    }

    public IEnumerator StartDialogCou()
    {
        UIMgr.Instance.BG.FadeIn(1, Color.black);
        yield return new WaitUntil(() => UIMgr.Instance.BG.IsDone);
        PauseAmbientSound();

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

        PlayAmbientSound();
        EnableAllInteractable();
    }

    public void StartSettle()
    {
        if(Q1Finish || Q2Finish || Q3Finish || Q4Finish || Q5Finish || Q6Finish || Q7Finish)
        {
            CallingOptions[0].OptionDatas[0].OptionAvailable = true;
        }
        
        if(Q2Finish || Q5Finish || Q6Finish || Q7Finish)
        {
            CallingOptions[1].OptionDatas[0].OptionAvailable = true;
        }

        if(Q2Finish)
        {
            CallingOptions[2].OptionDatas[1].OptionAvailable = true;
        }

        if(Q3Finish && Q4Finish)
        {
            CallingOptions[2].OptionDatas[0].OptionAvailable = true;
        }

        if(Q1Finish && Q2Finish && Q3Finish && Q4Finish && Q5Finish && Q6Finish && Q7Finish)
        {
            CallingOptions[3].OptionDatas[0].OptionAvailable = true;
        }

        StartCoroutine(SettleCou());
    }

    private IEnumerator SettleCou()
    {
        UIMgr.Instance.BG.FadeIn(2, Color.black);
        yield return new WaitUntil(() => UIMgr.Instance.BG.IsDone);

        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
        PauseAmbientSound();
        m_Source.PlayOneShot(BeginCallClip);
        yield return new WaitUntil(() => !m_Source.isPlaying);

        UIMgr.Instance.EnterOptions();
        UIMgr.Instance.Options.SetUpOptions(CallingOptions[CurOptionsIndex]);
        CurOptionsIndex++;
    }

    private IEnumerator StopCallCou()
    {
        m_Source.PlayOneShot(EndCallClip);
        yield return new WaitUntil(() => !m_Source.isPlaying);
    }

    private void OnGetOption(int optionIndex)
    {
        Debug.Log(optionIndex);
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
                                StartCoroutine(StopCallCou());
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
                                UIMgr.Instance.Options.SetUpOptions(CallingOptions[CurOptionsIndex]);
                                CurOptionsIndex++;
                                break;
                            }
                        case 1:
                            {
                                UIMgr.Instance.QuitOptions();
                                StartCoroutine(StopCallCou());
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                }
            case 3:
                {
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
                                StartCoroutine(StopCallCou());
                                break;
                            }
                        case 2:
                            {
                                UIMgr.Instance.QuitOptions();
                                StartCoroutine(StopCallCou());
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                }
            case 4:
                {
                    switch (optionIndex)
                    {
                        case 0:
                            {
                                UIMgr.Instance.Options.SetUpOptions(CallingOptions[CurOptionsIndex]);
                                CurOptionsIndex++;
                                StartCoroutine(StopCallCou());
                                break;
                            }
                        case 1:
                            {
                                UIMgr.Instance.QuitOptions();
                                StartCoroutine(StopCallCou());
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                }
            case 5:
                {
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
                        case 2:
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
