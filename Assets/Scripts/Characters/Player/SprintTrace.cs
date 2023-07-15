using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintTrace : MonoBehaviour, IGroundState
{
    [SerializeField] private GameObject traceParticlePrefab;
    public float existTime;

    private Sprint _sprint;

    private void Start()
    {
        _sprint = GetComponent<Sprint>();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void StateAction(Vector3 pos)
    {
        if (!_sprint.isSprint)
            return;
        StartCoroutine(CreateTraceParticle(pos));
    }

    private IEnumerator CreateTraceParticle(Vector3 pos)
    {
        var obj = Instantiate(traceParticlePrefab);
        obj.transform.position = pos;
        yield return null;
    }
}
