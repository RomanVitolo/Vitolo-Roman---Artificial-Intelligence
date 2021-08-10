using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState<T> : FSMState<T>
{
    private IMove _move;

    public WalkState(IMove move)
    {
        _move = move;
    }
    public override void Execute()
    {
        Debug.Log("Me estoy moviendo");
        _move.Move();
    }
}
