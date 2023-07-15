using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : Singleton<EnergyManager>,ISlider
{
    [SerializeField, Range(1, 5)] private float maxEnergy = 1.0f;

    private float _curEnergy;

    public float EnergyValue
    {   
        set { _curEnergy = Mathf.Clamp(value, 0.0f, maxEnergy); }
        get { return _curEnergy; }
    }

    protected override void Awake()
    {
        base.Awake();
        _curEnergy = maxEnergy;
    }

    private void Update()
    {
        
    }

    public bool PossessEnergy()
    {
        return _curEnergy > 0.0f;
    }

    public float GetSliderValue()
    {
        return EnergyValue / maxEnergy;
    }
}
