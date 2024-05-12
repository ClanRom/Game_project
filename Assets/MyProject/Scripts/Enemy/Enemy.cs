using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Attacker _attack;
    [SerializeField] private Health _health;


    private StateMachine _stateMachine;
    private Transform _target;
    private float _visionRadius = 10f;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;


        _stateMachine = new StateMachine();

        _stateMachine.AddState(new RestState(_stateMachine, _animator));
        _stateMachine.AddState(new PatrollingState(_stateMachine, _animator, _agent));
        _stateMachine.AddState(new PursuitState(_stateMachine, _animator, _attack, _agent, _target));
        _stateMachine.AddState(new AttackState(_stateMachine, _animator, _attack, _agent, _target, _health));


        _stateMachine.EnterIn<RestState>();
    }

    private void Update()
    {

        if (_health.IsDead)
            Destroy(this.gameObject, 5);
        else if (_stateMachine.CurrentState is not PursuitState && _stateMachine.CurrentState is not AttackState)
        {
            float distance = Vector3.Distance(_target.position, transform.position);
            if (distance <= _visionRadius && distance > _attack.RangeAttack)
                _stateMachine.EnterIn<PursuitState>();
            else if (distance <= _attack.RangeAttack)
                _stateMachine.EnterIn<AttackState>();
        }

        _stateMachine?.Update();

    }
}
