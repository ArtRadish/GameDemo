using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationSkill : MonoBehaviour,IMonsterSkill
{
    const string kSkillType = "SkillType";

    [Header("Base Setting")]
    [SerializeField] private GameObject translationTargetPrefab;
    [SerializeField] private GameObject translationObjPrefab;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float probability;
    [SerializeField] private float skillTime;

    [Header("TranslationObj Setting")]
    [SerializeField] private int number;
    [SerializeField] private float radius;
    [SerializeField] private float speed;


    private GameObject _translationTarget;
    private List<GameObject> _translationObjs = new List<GameObject>();
    private float _skillTime;
    private Animator _animator;

    private void Start()
    {
        _skillTime = skillTime;
        AddSkill();
        //SkillAction();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _skillTime = TranslationObjsAllDestroy() ? 0 : _skillTime;
    }

    private void FixedUpdate()
    {
        _skillTime = _skillTime > 0 ? (_skillTime - Time.deltaTime) : 0;
    }

    public MonsterSkillData GetSkillData()
    {
        MonsterSkillData monsterSkillData;
        monsterSkillData.skillTime = _skillTime / skillTime;
        monsterSkillData.skillProbability = probability;
        return monsterSkillData;
    }

    public void AddSkill()
    {
        MonsterSkillManager.Instance.monsterSkills.Add(this);
    }

    public void SkillAction()
    {
        _skillTime = skillTime;
        CreateTranslationTarget();
        CreateTranslationObj();
        _animator.SetInteger(kSkillType, 0);
    }

    public void SkillRevoke()
    {
        Destroy(_translationTarget);
        for (int i = 0; i < _translationObjs.Count; i++)
        {
            if (_translationObjs[i])
                Destroy(_translationObjs[i]);
        }
    }

    private void CreateTranslationTarget()
    {
        _translationTarget = Instantiate(translationTargetPrefab);
        _translationTarget.transform.position = targetPos;
    }

    private void CreateTranslationObj()
    {
        for (int i = 0; i < number; i++)
        {
            var obj = Instantiate(translationObjPrefab);
            Transform target = _translationTarget.transform;
            Quaternion rotation = Quaternion.AngleAxis(i * 360f / number, target.up);
            Vector3 point = target.right * radius;
            obj.transform.position = target.position + rotation * point;
            obj.GetComponent<Translation>().target = target;
            obj.GetComponent<Translation>().speed = speed;
            obj.GetComponent<TranslationSkillGetHit>().monsterBoss = gameObject;
            _translationObjs.Add(obj);
        }
    }

    private bool TranslationObjsAllDestroy()
    {
        if (_translationObjs.Count <= 0)
            return false;
        for (int i=0;i< _translationObjs.Count;i++)
        {
            if (_translationObjs[i])
                return false;
        }

        return true;
    }
}
