using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState<T>
{
    private Dictionary<T, FSMState<T>> _dic = new Dictionary<T, FSMState<T>>();
    
    public virtual void Awake() { }

    public virtual void Execute() { }
    
    public virtual void Sleep() { }

    public void AddTransition(T input, FSMState<T> state)
    {
        if (!_dic.ContainsKey(input))
        {
            _dic.Add(input, state);
        }
    }
    
    public void RemoveTransition(T input)
    {
        if (_dic.ContainsKey(input))
        {
            _dic.Remove(input);
        }
    }

    public FSMState<T> GetTransition(T input)
    {
        if (_dic.ContainsKey(input))
        {
            return _dic[input];
        }
        return null;
    }


}
