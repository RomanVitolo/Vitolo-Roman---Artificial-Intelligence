using System;
using UnityEngine;

public class Enemy2 : MonoBehaviour, IMove
{
    
    public float speed = 2f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }


    public void Move()
    {
        Debug.Log("entro al move de Enemy2");
        rb.velocity = Vector3.forward;
    }
    public void Escape()
    {
        Debug.Log("entre al Escape de Enemy");
    }
}