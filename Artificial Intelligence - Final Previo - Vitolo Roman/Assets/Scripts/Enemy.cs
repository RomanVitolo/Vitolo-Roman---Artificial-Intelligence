using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMove
{
    private EnemyController _enemyController;
    
    private void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    public void Move()
    {
        Debug.Log("entro al move de Enemy");
    }
    public void Escape()
    {
        Debug.Log("entre al Escape de Enemy");
    }
}
