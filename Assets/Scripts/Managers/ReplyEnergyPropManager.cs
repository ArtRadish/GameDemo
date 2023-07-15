using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReplyEnergyPropManager : Singleton<ReplyEnergyPropManager>
{
    [SerializeField] private GameObject propParfab;
    [SerializeField] private int maxPropNumber;
    [SerializeField] private float createTime;
    [SerializeField] private int rangeMin;
    [SerializeField] private int rangeMax;

    private int _curPropNumber;
    private float _curTime;

    private void Start()
    {
        for (int i = 0; i < maxPropNumber; i++)
            CreateProp();
        _curTime = createTime;
        _curPropNumber = maxPropNumber;
    }

    private void Update()
    {
        UpdateCreateProp();
    }

    private void FixedUpdate()
    {
        ReckonByTime();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void UpdateCreateProp()
    {
        if (_curTime > 0 || _curPropNumber >= maxPropNumber)
            return;

        CreateProp();
        _curPropNumber++;
        _curTime = createTime;
    }

    private void CreateProp()
    {
        var obj = Instantiate(propParfab);
        Vector3 pos = new Vector3(Random.Range(rangeMin, rangeMax + 1), obj.transform.position.y, Random.Range(rangeMin, rangeMax + 1));
        obj.transform.position = pos;
    }

    private void ReckonByTime()
    {
        if (_curTime <= 0)
            return;
        _curTime -= Time.deltaTime;
    }

    public void UseProp()
    {
        _curPropNumber--;
    }
    
    public void DestroyProp()
    {
        UseProp();
        _curTime = 0;
    }

}
