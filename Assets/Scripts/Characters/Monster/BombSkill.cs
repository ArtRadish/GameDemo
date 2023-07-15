using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombSkill : MonoBehaviour, IMonsterSkill
{
    const string kSkillType = "SkillType";

    [Header("Base Setting")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float probability;
    [SerializeField] private float skillTime;

    [Header("BombObj Setting")]
    [SerializeField] private float bombHeight;
    [SerializeField] private float bombSpeed;
    [SerializeField] private int rangePos;
    [SerializeField] private float needBloodValue;

    private float _skillTime;
    private Animator _animator;
    private List<Vector2> _points = new List<Vector2>();

    private void Start()
    {
        _skillTime = skillTime;
        AddSkill();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        _skillTime = _skillTime > 0 ? (_skillTime - Time.deltaTime) : 0;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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
        StartCoroutine(BombSkillAction());
    }

    public void SkillRevoke()
    {
        return;
    }

    private IEnumerator BombSkillAction()
    {
        int number = 5;
        for (int i=0;i< (int)skillTime/5;i++)
        {
            _animator.SetInteger(kSkillType, 1);
            StartCoroutine(CreateBombSkill(number));
            number *= 2;
            number = Mathf.Clamp(number, 5, 25);
            yield return new WaitForSeconds(2);
            GetComponent<IHit>().GetHitAction(needBloodValue);
            yield return new WaitForSeconds(3);
        }
    }

    private IEnumerator CreateBombSkill(int number)
    {
        _points.Clear();
        for (int i = 0; i < number; i++)
        {
            StartCoroutine(CreateDifferentPoint());
            StartCoroutine(CreateBombObjs(bombSpeed, i));
        }
        yield return null;
    }

    private IEnumerator CreateBombObjs(float speed,int posIndex)
    {
        var obj = Instantiate(bombPrefab);
        obj.transform.position = new Vector3(_points[posIndex].x * 10.0f, bombHeight, _points[posIndex].y * 10.0f);
        obj.transform.GetComponent<Translation>().speed = speed;

        yield return null;
    }

    private IEnumerator CreateDifferentPoint()
    {
        bool isDifferent = false;
        while (!isDifferent)
        {
            int x = Random.Range(0, rangePos + 1) - rangePos / 2;
            int y = Random.Range(0, rangePos + 1) - rangePos / 2;
            Vector2 pos = new Vector2((float)x, (float)y);

            isDifferent = true;
            for (int i=0;i<_points.Count;i++)
            {
                if (pos == _points[i])
                {
                    isDifferent = false;
                    break;
                }
            }

            if (isDifferent)
                _points.Add(pos);
        }

        yield return null;
    }
}
