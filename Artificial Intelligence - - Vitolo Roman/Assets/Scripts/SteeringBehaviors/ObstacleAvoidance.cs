using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class ObstacleAvoidance : ISteeringBehaviors
{
    private Transform _enemy;
    private Transform _target;
    private float _radius;
    private LayerMask _layerMask;
    private float _avoidWeight;

    public ObstacleAvoidance(Transform enemy, Transform target, float radius, LayerMask layerMask, float avoidWeight)
    {
        _enemy = enemy;
        _radius = radius;
        _layerMask = layerMask;
        _target = target;
        _avoidWeight = avoidWeight;
    }
    
    public Vector3 GetDir()
    {
        Collider[] obstacles = Physics.OverlapSphere(_enemy.position, _radius, _layerMask);
        Transform obsSave = null;
        var count = obstacles.Length;
        for (int i = 0; i < count; i++)
        {
            var currObs = obstacles[i].transform;
            if (obsSave == null)
            {
                obsSave = obstacles[i].transform;
            }
            else if (Vector3.Distance(_enemy.position, obsSave.position) > Vector3.Distance(_enemy.position, currObs.position))
            {
                obsSave = currObs;
            }
        }
        Vector3 dirToTarget = (_target.position - _enemy.position).normalized;
        if (obsSave != null)
        {
            Vector3 dirObsToObstacle = (_enemy.position - obsSave.position).normalized * _avoidWeight;
            dirToTarget += dirObsToObstacle;
        }
        return dirToTarget.normalized;
    }
}
