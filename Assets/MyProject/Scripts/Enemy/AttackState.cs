using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateSM
{
    private Attacker _attack;
    private NavMeshAgent _agent;
    private Transform _target;
    private Health _health;

    private bool CanAttack => Vector3.Distance(_agent.transform.position, _target.position) < _attack.RangeAttack;
    public AttackState(StateMachine machine, Animator animator, Attacker attack, NavMeshAgent agent, Transform target, Health health) : base(machine, animator)
    {
        _attack = attack;
        _agent = agent;
        _target = target;
        _health = health;
    }

    public override void Enter()
    {
        Debug.Log("[ENTER] ATTACKSTATE");
        _animator.SetFloat("Speed", 0);
    }

    public override void Exit()
    {
        Debug.Log("[EXICT] ATTACKSTATE");
        _agent.isStopped = false;
    }

    public override void Update()
    {
        Debug.Log("[UPDATE] ATTACKSTATE");

        if (_health.IsDead)
        {
            _machine.EnterIn<RestState>();
        }
        else
        {
            if (_attack.CanAttack)
                _attack.Attack();

            if (!CanAttack)
                _machine.EnterIn<PursuitState>();
        }

    }
}
