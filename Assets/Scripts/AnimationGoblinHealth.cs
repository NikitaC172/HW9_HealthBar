using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationGoblinHealth : MonoBehaviour
{
    private Animator _animator = null;
    private Goblin _goblin = null;
    private const string HealthAnimator = "Health";

    private void Update()
    {
        _animator.SetFloat(HealthAnimator, _goblin.Health);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _goblin = GetComponent<Goblin>();
    }
}
