using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplyEnergy : MonoBehaviour
{
    const string kPlayer = "Player";
    const string kObstacle = "Obstacle";

    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float value;

    private GroundChecker _groundChecker;

    private void Start()
    {
        _groundChecker = GetComponent<GroundChecker>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == kPlayer)
    //        StartCoroutine(Reply());
    //    if(other.tag == kObstacle)
    //        StartCoroutine(Obstacle());
    //}

    private void Update()
    {
        if (_groundChecker.IsOnGround)
            Trigger(_groundChecker.colliders[0]);
    }

    private void Trigger(Collider other)
    {
        if (other.tag == kPlayer)
            StartCoroutine(Reply());
        if (other.tag == kObstacle)
            StartCoroutine(Obstacle());
    }

    IEnumerator Reply()
    {
        EnergyManager.Instance.EnergyValue += value;
        var obj = Instantiate(particlePrefab);
        obj.transform.position = transform.position;
        ReplyEnergyPropManager.Instance.UseProp();
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator Obstacle()
    {
        ReplyEnergyPropManager.Instance.DestroyProp();
        Destroy(gameObject);
        yield return null;
    }
}
