using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GroundType { NONE, TRACE };
public class GroundTypeAction : MonoBehaviour
{
    const string kPlayer = "Player";

    [SerializeField] private GroundType groundType;

    GroundChecker _checker;

    private void Start()
    {
        _checker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        GroundTypeState();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void GroundTypeState()
    {
        switch (groundType)
        {
            case GroundType.NONE:
                NoneAction();
                break;
            case GroundType.TRACE:
                TraceAction();
                break;
            default:
                break;
        }
    }

    private void NoneAction()
    {
        if (!_checker.IsOnGround)
            return;

        for (int i = 0; i < _checker.colliders.Length; i++)
        {
            GameObject obj = _checker.colliders[i].gameObject;
            if (obj.tag == kPlayer)
            {
                obj.GetComponent<SprintTrace>().StateAction(transform.position);
                StartCoroutine(Restore(obj.GetComponent<SprintTrace>().existTime));
                groundType = GroundType.TRACE;
            }
        }
    }

    private void TraceAction()
    {
        if (!_checker.IsOnGround)
            return;
    }

    private IEnumerator Restore(float time)
    {
        yield return new WaitForSeconds(time);
        groundType = GroundType.NONE;
        yield return null;
    }

}
