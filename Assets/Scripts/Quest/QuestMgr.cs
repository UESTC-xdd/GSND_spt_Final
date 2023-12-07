using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestMgr : Singleton<QuestMgr>
{
    public List<Quest> QuestList = new List<Quest>();

    public Dictionary<string, Quest> QuestsDic = new Dictionary<string, Quest>();

    public UnityAction<Quest> OnQuestFinished;

    private void Start()
    {
        foreach (var quest in QuestList)
        {
            QuestsDic.Add(quest.QuestName, quest);
        }
    }

    public void AddQuest(string QuestName)
    {

    }

    public void OnFinishQuest(string QuestName,QuestComp questComp)
    {
        if(QuestsDic.ContainsKey(QuestName))
        {
            if (QuestsDic[QuestName].QuestComps.Contains(questComp)) 
            {
                QuestsDic[QuestName].QuestComps.Remove(questComp);

                Debug.Log("One of Quest " + QuestName + "'s goal achieved");

                if(QuestsDic[QuestName].QuestComps.Count<=0)
                {
                    OnQuestFinished?.Invoke(QuestsDic[QuestName]);
                    QuestsDic.Remove(QuestName);

                    Debug.Log("Quest " + QuestName + " accomplished");
                }
            }
        }
        else
        {

        }
    }
}

[Serializable]
public class Quest
{
    public string QuestName;
    public List<QuestComp> QuestComps = new List<QuestComp>();
}