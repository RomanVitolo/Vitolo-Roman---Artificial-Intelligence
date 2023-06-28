using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_rb.velocity.z >= 0.5f)
        {
            _animator.SetFloat("Vel", Mathf.Abs(_rb.velocity.z));
        }
    }
}
