using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ButtonChangeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color _hoverСolor;

    private Image _image = null;
    private Color _currentColor;
    private float _timeChange = 1f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.DOColor(_hoverСolor, _timeChange);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.DOColor(_currentColor, _timeChange);
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _currentColor = _image.color;
    }
}
