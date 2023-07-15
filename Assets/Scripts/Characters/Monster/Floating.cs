using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    const string kPlayer = "Player";
    const string kIsFloating = "IsFloating";

    [SerializeField] private float floatingTime;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    private Transform _player; 
    private bool _isMove;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == kPlayer && !_isMove)
        {
            _isMove = true;
            _player = other.transform;
            gameObject.GetComponent<CircularMotion>().isMotion = false;
            StartCoroutine(FloatingEnd());
        }
    }

    private void OnDisable()
    {
        StopCoroutine(FloatingEnd());
    }

    private void OnDestroy()
    {
        if (!_player)
            return;
        SetEnabled(true);
    }

    private void Move()
    {
        if (!_isMove || !_player)
            return;

        SetEnabled(false);
        Vector3 dir = transform.position + offset - _player.position;
        _isMove = dir.magnitude >= 0.1f;
        dir.Normalize();
        _player.Translate(dir * Time.deltaTime * speed, Space.World);
    }

    private void SetEnabled(bool isEnabled)
    {
        if (!_player)
            return;
        _player.GetComponent<Jump>().enabled = isEnabled;
        _player.GetComponent<Movement>().enabled = isEnabled;
        _player.GetComponent<PlayerInput>().enabled = isEnabled;
        _player.GetComponent<Animator>().SetBool(kIsFloating, !isEnabled);
    }

    private IEnumerator FloatingEnd()
    {
        yield return new WaitForSeconds(floatingTime);
        SetEnabled(true);
        Destroy(gameObject);
    }
}
