using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IIdle, IAttack
{
    [SerializeField] private Transform target;
    public bool inSight = true;
    private LineOfSight _lineOfSight;
    private Rigidbody rb;
    [SerializeField] private Rigidbody rbTarget;
    private FSM<string> _fsm;
    private Enemy _enemy;
    private float timePrediction = 2f;
    private float speed = 2f;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float avoidWeight = 0.5f;
    [SerializeField] private LayerMask mask;
    private ISteeringBehaviors _steeringBehaviors;

    private Enemy2 _enemy2;
    //private IMove _move;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _lineOfSight = GetComponent<LineOfSight>();
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _steeringBehaviors = new Pursuit(transform, target, rbTarget, timePrediction);
        _steeringBehaviors = new ObstacleAvoidance(transform, target, radius, mask, avoidWeight);
        _enemy2 = GetComponent<Enemy2>();
        InitializeStateMachine();
    }

    void Update()
    { 
        if (_lineOfSight.IsInSight(target))
        {
            Debug.Log("veo al enemigo");
            _fsm.DoTransition("pursuit");
        }
        if(!_lineOfSight.IsInSight(target))
        {
            Debug.Log("No veo al enemigo");
            _fsm.DoTransition("escape");
        }
        _fsm.OnUpdate();
    }

    void InitializeStateMachine()
    {
        _fsm = new FSM<string>();
        
        IdleState<string> idle = new IdleState<string>(this);
        PursuitState<string> pursuit = new PursuitState<string>(this);
        WalkState<string> walk = new WalkState<string>(_enemy);
        ShootState<string> shoot = new ShootState<string>(this);
        ReloadState<string> reload = new ReloadState<string>(this);
        EscapeState<string> escape = new EscapeState<string>(_enemy);

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
        _fsm.DoTransition("walk");
    }

   public void Pursuit()
   {
       var dir = _steeringBehaviors.GetDir();
       _enemy.GoMove(dir.normalized);
   }
    public void Shoot()
    {
        Debug.Log("entre en el Shoot");
        _fsm.DoTransition("reload");
    }
    public void Reload()
    {
        
    }

    IEnumerator WaitToRecover()
    {
        yield return new WaitForSeconds(1);
        
    }
}
