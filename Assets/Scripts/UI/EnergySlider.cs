using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    public float speed;
    public GameObject sliderObj;

    private Slider _slider;
    private float _energyProportion;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _energyProportion = sliderObj.GetComponent<ISlider>().GetSliderValue();
        _slider.value = _energyProportion;
    }

    private void Update()
    {
        SliderLeftMove();
        SliderRightMove();
    }

    private void SliderLeftMove()
    {
        if (_slider == null)
            return;

        _energyProportion = sliderObj.GetComponent<ISlider>().GetSliderValue();
        if (_slider.value <= _energyProportion)
            return;
        _slider.value -= Time.deltaTime * speed;
    }

    private void SliderRightMove()
    {
        if (_slider == null)
            return;

        _energyProportion = sliderObj.GetComponent<ISlider>().GetSliderValue();
        if (_slider.value >= _energyProportion)
            return;
        _slider.value += Time.deltaTime * speed;
    }
}
