using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthCharacter _goblin = null;
    [SerializeField] private Image _fillArea = null;

    private Slider _slider = null;
    private float _currentValue;
    private float _timeChangeValue = 1.5f;
    private const float HundredthPart = 100f;

    public void ChangeHealth()
    {
        ChangeValue();
        ChangeColor();
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _goblin.Health;
        _currentValue = _goblin.Health;
        _fillArea.color = Color.Lerp(Color.red, Color.green, _slider.value / HundredthPart);
    }

    private void ChangeValue()
    {
        if (_currentValue != _goblin.Health)
        {
            _currentValue = _goblin.Health;
            _slider.DOValue(_currentValue, _timeChangeValue, true);
        }
    }

    private void ChangeColor()
    {
        if (_currentValue != _slider.value)
        {
            _fillArea.color = Color.Lerp(Color.red, Color.green, _slider.value / HundredthPart);
        }
    }
}
