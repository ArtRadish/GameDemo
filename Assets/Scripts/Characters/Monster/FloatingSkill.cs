using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSkill : MonoBehaviour,IMonsterSkill
{
    const string kSkillType = "SkillType";

    [Header("Base Setting")]
    [SerializeField] private GameObject floatingPrefab;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float probability;
    [SerializeField] private float skillTime;

    [Header("FloatingObj Setting")]
    [SerializeField] private int number;
    [SerializeField] private Vector2 rangeSpeed;
    [SerializeField] private float offset;

    private List<GameObject> _floatingObjs = new List<GameObject>();
    private float _skillTime;
    private Animator _animator;
    private void Start()
    {
        _skillTime = skillTime;
        _animator = GetComponent<Animator>();
        AddSkill();
    }

    private void Update()
    {
        _skillTime = FloatingAllDestroy() ? 0 : _skillTime;
    }
    private void FixedUpdate()
    {
        _skillTime = _skillTime > 0 ? (_skillTime - Time.deltaTime) : 0;
    }

    public void AddSkill()
    {
        MonsterSkillManager.Instance.monsterSkills.Add(this);
    }

    public MonsterSkillData GetSkillData()
    {
        MonsterSkillData monsterSkillData;
        monsterSkillData.skillTime = _skillTime / skillTime;
        monsterSkillData.skillProbability = probability;
        return monsterSkillData;
    }

    public void SkillAction()
    {
        _skillTime = skillTime;
        _animator.SetInteger(kSkillType, 0);
        CreateFloatingObjs();
    }

    public void SkillRevoke()
    {
        for(int i = 0;i< _floatingObjs.Count;i++)
        {
            if (_floatingObjs[i])
                Destroy(_floatingObjs[i]);
        }
    }

    private void CreateFloatingObjs()
    {
        for (int i = 0; i < number; i++)
        {
            var obj = Instantiate(floatingPrefab);
            obj.GetComponent<CircularMotion>().speed = Random.Range(rangeSpeed.x, rangeSpeed.y);
            obj.GetComponent<CircularMotion>().raduis = (i+1) * obj.transform.localScale.x * offset;
            _floatingObjs.Add(obj);
        }
    }

    private bool FloatingAllDestroy()
    {
        if (_floatingObjs.Count <= 0)
            return false;
        for (int i = 0; i < _floatingObjs.Count; i++)
        {
            if (_floatingObjs[i])
                return false;
        }

        return true;
    }
}
