using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] private float _health = 50.0f;
    [SerializeField] private UnityEvent _cured = new UnityEvent();
    [SerializeField] private UnityEvent _hurted = new UnityEvent();
    [SerializeField] private UnityEvent _dead = new UnityEvent();
    [SerializeField] private UnityEvent _changedHealth = new UnityEvent();

    private float _healtMax = 100.0f;

    public float Health => _health;

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _hurted?.Invoke();            

            if (_health - damage > 0)
            {
                _health -= damage;
            }
            else
            {
                _health = 0;
                _dead?.Invoke();
            }

            _changedHealth?.Invoke();
        }
    }

    public void Treat(float health)
    {
        if (_health < _healtMax)
        {
            _cured?.Invoke();            

            if (_health + health < _healtMax)
            {
                _health += health;

            }
            else
            {
                _health = _healtMax;
            }

            _changedHealth?.Invoke();
        }
    }
}
