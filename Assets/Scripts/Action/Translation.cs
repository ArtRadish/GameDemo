using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public Transform target;
    public float speed;

    private bool _isMove;
    private Vector3 _dir;
    //float time;
    public bool isMove { get { return _isMove; }set { _isMove = value; } }

    private void Start()
    {
        _isMove = true;
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        //time += Time.deltaTime;
        //Debug.Log(time);
    }

    private void Move()
    {
        if (!_isMove)
            return;
        _dir = target.position - transform.position;
        _isMove = _dir.magnitude >= 0.5f;
        _dir.Normalize();
        transform.Translate(_dir * Time.deltaTime * speed, Space.Self);
    }
}
