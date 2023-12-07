using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComp : MonoBehaviour
{
    public string QuestName;

    public void OnFinishQuest()
    {
        QuestMgr.Instance.OnFinishQuest(QuestName, this);
    }
}
