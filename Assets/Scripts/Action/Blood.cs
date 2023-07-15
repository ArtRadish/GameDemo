using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Blood : MonoBehaviour,IHit, ISlider
{
    private string kGetHit = "GetHit";

    [SerializeField] private float maxBlood;

    private Animator _animator;
    private float _curBlood;
    public float CurBlood { get { return _curBlood; } set{ _curBlood = value; } }

    private void Awake()
    {
        _curBlood = maxBlood;
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public float GetSliderValue()
    {
        return _curBlood / maxBlood;
    }

    public void GetHitAction(float value)
    {
        _curBlood -= value;
        _animator.SetTrigger(kGetHit);
    }
}
