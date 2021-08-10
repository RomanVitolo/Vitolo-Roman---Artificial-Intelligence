using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState<T> : FSMState<T>
{
    private IAttack _followTarget;

    public PursuitState(IAttack followTarget)
    {
        _followTarget = followTarget;
    }

    public override void Execute()
    {
        Debug.Log("Persigo al enemigo");
        _followTarget.Pursuit();
    }
}
