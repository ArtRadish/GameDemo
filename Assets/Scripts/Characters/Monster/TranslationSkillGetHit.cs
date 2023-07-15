using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationSkillGetHit : MonoBehaviour,IHit
{
    [HideInInspector] public GameObject monsterBoss;

    public void GetHitAction(float value)
    {
        if (!monsterBoss)
            return;

        monsterBoss.GetComponent<IHit>().GetHitAction(value);
    }
}
