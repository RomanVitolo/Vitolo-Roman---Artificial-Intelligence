using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState<T> : FSMState<T>
{
    private IAttack _shoot;

    public ShootState(IAttack shoot)
    {
        _shoot = shoot;
    }

    public override void Execute()
    {
        Debug.Log("Estoy disparando");
        _shoot.Shoot();
    }
}
