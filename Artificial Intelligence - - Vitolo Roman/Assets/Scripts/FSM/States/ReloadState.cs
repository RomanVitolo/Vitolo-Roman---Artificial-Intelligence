using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState<T> : FSMState<T>
{
    private IAttack _reloadAmmo;
    private Enemy _enemy;

    public ReloadState(IAttack reloadAmmo)
    {
        _reloadAmmo = reloadAmmo;
    }

    public override void Execute()
    {
        Debug.Log("Estoy recargando");
        _reloadAmmo.Reload();
    }
}
