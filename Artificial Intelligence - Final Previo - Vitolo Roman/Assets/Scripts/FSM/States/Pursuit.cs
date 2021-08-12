using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class Pursuit : ISteeringBehaviors
{
    private Transform _target;
    private Transform _npc;
    private Rigidbody _rbTarget;
    private float _timePrediction;

    public Pursuit(Transform npc, Transform target, Rigidbody rbTarget, float timePrediction)
    { 
        _npc = npc;
        _target = target;
        _rbTarget = rbTarget;
        _timePrediction = timePrediction;
    }
    
    public Vector3 GetDir()
    {
        var vel = _rbTarget.velocity.magnitude;
        Vector3 posPrediction = _target.transform.position + _target.transform.forward * vel * _timePrediction;
        Vector3 dir = (posPrediction - _npc.position).normalized;
        return Vector3.zero;
    }
}
