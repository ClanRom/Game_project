using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingState : StateSM
{
    private NavMeshAgent _agent;
    private float _speed = 1f;
    private List<Transform> _point = new List<Transform>();
    private float _time;
    public PatrollingState(StateMachine machine, Animator animator, NavMeshAgent agent) : base(machine, animator)
    {
        _agent = agent;
    }

    public override void Enter()
    {
        Debug.Log("[ENTER] PATROLLING");
        _time = 0f;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Point").transform;
        foreach (Transform item in pointsObject)
            _point.Add(item);

        _agent.speed = _speed;
        _animator.SetFloat("Speed", _speed);
        _agent.SetDestination(_point[0].position);
    }

    public override void Exit()
    {
        Debug.Log("[EXICT] PATROLLING");
    }

    public override void Update()
    {
        Debug.Log("[UPDATE] PATROLLING");
        _time += Time.deltaTime;

        if (_time > 20 && !_agent.hasPath)
            _machine.EnterIn<RestState>();

        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_point[Random.Range(0, _point.Count)].position);

    }
}
