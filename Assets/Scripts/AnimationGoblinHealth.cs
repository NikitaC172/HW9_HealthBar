using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationGoblinHealth : MonoBehaviour
{
    private Animator _animator = null;
    private HealthCharacter _goblin = null;
    private const string HealthAnimator = "Health";
    private const string HurtTrigger = "Hurt";
    private const string DeadTrigger = "Dead";
    private const string HealingTrigger = "Healing";

    public void Die()
    {
        _animator.SetTrigger(DeadTrigger);
    }

    public void Treat()
    {
        _animator.SetTrigger(HealingTrigger);
    }

    public void Hurt()
    {
        _animator.SetTrigger(HurtTrigger);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _goblin = GetComponent<HealthCharacter>();
    }

    private void OnEnable()
    {
        _goblin.Die += Die;
        _goblin.Hurt += Hurt;
        _goblin.TreatHealth += Treat;
    }

    private void OnDisable()
    {
        _goblin.Die -= Die;
        _goblin.Hurt -= Hurt;
        _goblin.TreatHealth -= Treat;
    }
}
