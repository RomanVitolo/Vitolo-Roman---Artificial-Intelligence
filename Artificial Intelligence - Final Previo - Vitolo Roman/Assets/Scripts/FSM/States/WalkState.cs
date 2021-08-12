using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState<T> : FSMState<T>
{
    private IMove _walk;

    public WalkState(IMove walk)
    {
        _walk = walk;
    }
    public override void Execute()
    {
        Debug.Log("Me estoy moviendo");
        _walk.Move();
    }
}
