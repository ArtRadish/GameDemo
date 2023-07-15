using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float speed = 100;
    public float raduis = 5;
    public bool isMotion;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Motion();
    }

    private void Motion()
    {
        if (!isMotion)
            return;
        Quaternion rotation = Quaternion.AngleAxis(speed * Time.time, Vector3.up);
        Vector3 point = Vector3.right * raduis;
        transform.position = rotation * point;
    }
}
