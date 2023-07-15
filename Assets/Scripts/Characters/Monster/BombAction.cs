using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Translation))]
public class BombAction : MonoBehaviour
{
    [SerializeField] private GameObject bombParticlePrefab;
    [SerializeField] private GameObject bombRangePrefab;

    private Translation _translation;
    private GameObject _bombRangeGameObject;

    private void Start()
    {
        _bombRangeGameObject = Instantiate(bombRangePrefab);
        Vector3 pos = new Vector3(transform.position.x, 1.0f, transform.position.z);
        _bombRangeGameObject.transform.position = pos;

        _translation = GetComponent<Translation>();
        _translation.target = _bombRangeGameObject.transform;
    }

    private void Update()
    {
        Reach();
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void Reach()
    {
        if (_translation.isMove)
            return;

        var obj = Instantiate(bombParticlePrefab);
        obj.transform.position = transform.position;
        Destroy(_bombRangeGameObject);
        Destroy(gameObject);
    }
}
