using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PursuitState : StateSM
{
    private NavMeshAgent _agent;
    private Transform _target;
    private Attacker _attack;
    private float _speed;
    private float _maxSpeed;

    private float _distanceToTarget = 15f;
    private bool ZoneToTarget => Vector3.Distance(_target.position, _agent.nextPosition) < _distanceToTarget;
    private float _time = 0;
    private float _timerToTarget = 1;
    public PursuitState(StateMachine machine, Animator animator, Attacker attack, NavMeshAgent agent, Transform target, float speed) : base(machine, animator)
    {
        _agent = agent;
        _attack = attack;
        _target = target;
        _maxSpeed = speed;
    }

    public override void Enter()
    {
        Debug.Log("[ENTER] PURSUIT");
        _speed = _maxSpeed;
        _agent.speed = _speed;
        _animator.SetFloat("Speed", _speed);
    }

    public override void Exit() => Debug.Log("[EXIT] PURSUIT");

    public override void Update()
    {
        Debug.Log("[UPDATE] PURSUIT");

        _agent.SetDestination(_target.position);

        if (Vector3.Distance(_target.position, _agent.nextPosition) < _attack.RangeAttack)
        {
            _agent.isStopped = true;
            _machine.EnterIn<AttackState>();
        }

        if (!ZoneToTarget && _time > _timerToTarget)
            _machine.EnterIn<PatrollingState>();
        else if (!ZoneToTarget)
            _time += Time.deltaTime;
        else
            _time = 0;

    }
}
