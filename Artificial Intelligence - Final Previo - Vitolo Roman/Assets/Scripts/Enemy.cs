using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMove
{
    private EnemyController _enemyController;
    public float speed = 2f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _enemyController = GetComponent<EnemyController>();
    }
    public void Move()
    {
        Debug.Log("entro al move de Enemy");
    }
    public void GoMove(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
    }
    
    public void Escape()
    {
        Debug.Log("entre al Escape de Enemy");
    }
}
