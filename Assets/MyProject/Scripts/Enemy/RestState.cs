using UnityEngine;

public class RestState : StateSM
{
    private float _time;
    public RestState(StateMachine machine, Animator animator) : base(machine, animator)
    {

    }

    public override void Enter()
    {
        Debug.Log("[ENTER] Idle");
        _animator.SetFloat("Speed", 0);
        _time = 0f;

    }

    public override void Exit() => Debug.Log("[EXIT] Idle");

    public override void Update()
    {
        Debug.Log("[UPDATE] Idle");
        _time += Time.deltaTime;
        if (_time > 5)
            _machine.EnterIn<PatrollingState>();
    }
}
