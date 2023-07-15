using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterSkill
{
    public MonsterSkillData GetSkillData();

    public void AddSkill();
    public void SkillAction();
    public void SkillRevoke();
}
