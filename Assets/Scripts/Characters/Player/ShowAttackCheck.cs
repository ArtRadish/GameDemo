using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAttackCheck : MonoBehaviour
{
    [SerializeField] private float checkTime;
    private Collider _collider;
    //private MeshRenderer meshRenderer;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        //meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.enabled = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void StartCheck()
    {
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        _collider.enabled = true;
        //meshRenderer.enabled = true;
        yield return new WaitForSeconds(checkTime);
        _collider.enabled = false;
        //meshRenderer.enabled = false;
    }
}
