using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct MonsterSkillData
{
    public float skillTime;
    public float skillProbability;
}

public class MonsterSkillManager : Singleton<MonsterSkillManager>,ISlider
{
    [SerializeField] private float skillIntervalTime = 5.0f;


    public List<IMonsterSkill> monsterSkills = new List<IMonsterSkill>();
    [HideInInspector]public int curSkillIndex = -1;

    private MonsterSkillData _curMonsterSkillData;
    private float _curSkillIntervalTime;

    protected override void Awake()
    {
        _curSkillIntervalTime = skillIntervalTime;
        base.Awake();
    }

    private void Update()
    {
        UpdateSkill();
    }

    private void RandomGenerateSkill()
    {
        if (monsterSkills.Count <= 0)
            return;

        curSkillIndex = Random.Range(0, monsterSkills.Count);
        monsterSkills[curSkillIndex].SkillAction();
    }

    private void UpdateSkill()
    {
        if (curSkillIndex < 0 && ReckonByTime())
            RandomGenerateSkill();
        if (curSkillIndex < 0)
            return;

        _curMonsterSkillData = monsterSkills[curSkillIndex].GetSkillData();
        if (_curMonsterSkillData.skillTime <= 0)
        {
            monsterSkills[curSkillIndex].SkillRevoke();
            curSkillIndex = -1;
            _curSkillIntervalTime = skillIntervalTime;
        }
    }

    private bool ReckonByTime()
    {
        if (_curSkillIntervalTime <= 0.0f)
            return true;
        _curSkillIntervalTime -= Time.deltaTime;
        return false;
    }

    public float GetSliderValue()
    {
        if (curSkillIndex < 0)
            return 1.0f;
        return _curMonsterSkillData.skillTime;
    }
}
