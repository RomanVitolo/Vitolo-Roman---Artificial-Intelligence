using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : FSMState<T>
{
    private IIdle _idle;

    public IdleState(IIdle idle)
    {
        _idle = idle;
    }

    // public override void Awake()
    // {
    //     Debug.Log("Arranco en Idle");
    //     _idle.DoIdle();
    // }
    
    public override void Execute()
    {
        Debug.Log("Idle State");
        _idle.DoIdle();
    }
}

