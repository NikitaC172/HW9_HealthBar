using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class GoblinClicer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _health = 50.0f;
    [SerializeField] private float _damage = 10.0f;
    [SerializeField] private float _healing = 10.0f;

    private Animator _animator = null;
    private float _healtMax = 100.0f;

    private const string HurtTrigger = "Hurt";
    private const string HealingTrigger = "Healing";

    public float Health => _health;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            TakeDamage(_damage);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Treat(_healing);
        }
    }

    private void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _animator.SetTrigger(HurtTrigger);

            if (_health - damage > 0)
            {
                _health -= damage;
            }
            else
            {
                _health = 0;
            }
        }
    }

    private void Treat(float health)
    {
        if (_health < _healtMax)
        {
            _animator.SetTrigger(HealingTrigger);

            if (_health + health < _healtMax)
            {
                _health += health;
            }
            else
            {
                _health = _healtMax;
            }
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
