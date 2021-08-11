using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IMove, IIdle, IAttack
{
    [SerializeField] private Transform target;
   // public bool inSight = false;
    private LineOfSight _lineOfSight;
    private Rigidbody rb;
    private FSM<string> _fsm;
    float _currentWalkedTime = 4f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _lineOfSight = GetComponent<LineOfSight>();
    }

    private void Start()
    {
        InitializeStateMachine();
    }

    void Update()
    {
        //_fsm.OnUpdate();
        if (Time.timeScale == 1)
        {
            _fsm.OnUpdate();
        }
    }

    void InitializeStateMachine()
    {
        _fsm = new FSM<string>();
        
        IdleState<string> idle = new IdleState<string>(this);
        PursuitState<string> pursuit = new PursuitState<string>(this);
        WalkState<string> walk = new WalkState<string>(this);
        ShootState<string> shoot = new ShootState<string>(this);
        ReloadState<string> reload = new ReloadState<string>(this);
        EscapeState<string> escape = new EscapeState<string>(this);

        idle.AddTransition("walk", walk);
        idle.AddTransition("pursuit", pursuit);
        idle.AddTransition("shoot", shoot);
        idle.AddTransition("reload", reload);
        idle.AddTransition("escape", escape);
        
        walk.AddTransition("idle", idle);
        walk.AddTransition("pursuit", pursuit);
        walk.AddTransition("shoot", shoot);
        walk.AddTransition("reload", reload);
        walk.AddTransition("escape", escape);
        
        pursuit.AddTransition("idle", idle);
        pursuit.AddTransition("walk", walk);
        pursuit.AddTransition("shoot", shoot);
        pursuit.AddTransition("reload", reload);
        pursuit.AddTransition("escape", escape);
        
        shoot.AddTransition("idle", idle);
        shoot.AddTransition("walk", walk);
        shoot.AddTransition("pursuit", pursuit);
        shoot.AddTransition("reload", reload);
        shoot.AddTransition("escape", escape);
        
        reload.AddTransition("idle", idle);
        reload.AddTransition("walk", walk);
        reload.AddTransition("pursuit", pursuit);
        reload.AddTransition("shoot", shoot);
        reload.AddTransition("escape", escape);
        
        escape.AddTransition("idle", idle);
        escape.AddTransition("walk", walk);
        escape.AddTransition("pursuit", pursuit);
        escape.AddTransition("shoot", shoot);
        escape.AddTransition("reload", reload);
        
        _fsm.SetInitialState(idle);
    }
    
    
    public void DoIdle()
    {
        StartCoroutine(WaitToRecover());
    }

    public void Pursuit()
    {
        if(!_lineOfSight.IsInSight(target))
        {
            Debug.Log("No veo al enemigo");
            _fsm.DoTransition("shoot");
        }
    }
    public void Shoot()
    {
        Debug.Log("entre en el Shoot");
        _fsm.DoTransition("reload");
    }
    public void Reload()
    {
        
    }
    public void Move()
    {
        if(_lineOfSight.IsInSight(target))
        {
         Debug.Log("Veo al Enemigo");
         _fsm.DoTransition("pursuit");
        }
        else
        {
            _fsm.DoTransition("escape");
        }
    }
    
    public void Escape()
    {
        
    }
    
    IEnumerator WaitToRecover()
    {
        yield return new WaitForSeconds(1);
        _currentWalkedTime = 0;
        if (_currentWalkedTime == 0)
        {
            _fsm.DoTransition("walk");
            Debug.Log("Entre al IF");
        }
    }
}
