using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationObjRemove : MonoBehaviour
{
    const string kGetHurt = "Attack";

    [SerializeField] private GameObject getHurtParticles;

    private Translation _translation;
    private bool _getHurt;

    private void Start()
    {
        _translation = GetComponent<Translation>(); 
    }

    private void Update()
    {
        Remove();
    }

    private void OnTriggerEnter(Collider other)
    {
        _getHurt = other.tag == kGetHurt;
    }

    private void Remove()
    {
        if (!_translation.isMove)
            Destroy(gameObject);
        else if(_getHurt)
        {
            var obj = Instantiate(getHurtParticles);
            obj.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

}
