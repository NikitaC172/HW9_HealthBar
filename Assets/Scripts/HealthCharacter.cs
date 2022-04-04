using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] private float _health = 50.0f;
    private UnityEvent _cured = new UnityEvent();
    private UnityEvent _hurted = new UnityEvent();
    private UnityEvent _dead = new UnityEvent();
    private UnityEvent _changedHealth = new UnityEvent();

    private float _healtMax = 100.0f;

    public float Health => _health;

    public event UnityAction TreatHealth
    {
        add => _cured.AddListener(value);
        remove => _cured.RemoveListener(value);
    }

    public event UnityAction ChangeHealth
    {
        add => _changedHealth.AddListener(value);        
        remove => _changedHealth.RemoveListener(value);
    }

    public event UnityAction Hurt
    {
        add => _hurted.AddListener(value);
        remove => _hurted.RemoveListener(value);
    }

    public event UnityAction Die
    {
        add => _dead.AddListener(value);
        remove => _dead.RemoveListener(value);
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _hurted?.Invoke();
            _health = Mathf.Clamp(_health - damage, 0, _healtMax);
            _changedHealth?.Invoke();

            if (_health == 0)
            {
                _dead?.Invoke();
            }
        }
    }

    public void Treat(float health)
    {
        if (_health < _healtMax)
        {
            _cured?.Invoke();
            _health = Mathf.Clamp(_health + health, 0, _healtMax);
            _changedHealth?.Invoke();
        }
    }
}
