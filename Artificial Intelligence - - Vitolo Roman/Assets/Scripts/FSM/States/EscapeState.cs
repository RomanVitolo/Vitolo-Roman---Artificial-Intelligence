using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState<T> : FSMState<T>
{
    private IMove _escape;

    public EscapeState(IMove escape)
    {
        _escape = escape;
    }

    public override void Execute()
    {
        _escape.Escape();
    }
}

