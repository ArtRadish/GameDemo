using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackHurt : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float hitValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
            other.GetComponent<IHit>().GetHitAction(hitValue);
    }
}
