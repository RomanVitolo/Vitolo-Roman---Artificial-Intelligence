using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : INode
{
    public delegate void _myDelegate();
    _myDelegate _action;

    public ActionNode(_myDelegate action)
    {
        _action = action;
    }

    public void SubAction(_myDelegate newAction)
    {
        _action += newAction;
    }
    
    public void Execute()
    {
        _action();
    }
}
