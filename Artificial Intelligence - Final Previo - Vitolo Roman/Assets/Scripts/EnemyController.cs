using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public bool inSight;
    private LineOfSight _lineOfSight;
    private Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _lineOfSight = GetComponent<LineOfSight>();
    }

     void Update()
    {
        if (_lineOfSight.IsInSight(target))
        {
            Debug.Log("Veo al Enemigo");
            inSight = true;
        }
        else
        {
            Debug.Log("No veo al enemigo");
            inSight = false; 
        }
    }
}
