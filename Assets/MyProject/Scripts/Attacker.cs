using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _cooldownAttack;
    private float _cooldownTimer;
    private float _range = 1f;
    private float _damage = 25f;
    private Collider[] _hits = new Collider[3];

    public bool CanAttack => _cooldownTimer <= 0;
    public float RangeAttack => _range;

    void Start() => ResetAttackTimer();

    void Update() => _cooldownTimer -= Time.deltaTime;

    public void Attack()
    {
        AnimateAttack();
        AttackOfTarget();
        ResetAttackTimer();
    }

    private void ResetAttackTimer() => _cooldownTimer = _cooldownAttack;

    private void AttackOfTarget()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, _range, _hits, _layerMask);

        for (int i = 0; i < count; i++)
        {
            if (_hits[i].TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
    private void AnimateAttack()
    {
        int index = Random.Range(0, 2);
        _animator.SetInteger("IndexAttack", index);
        _animator.SetTrigger("Attacking");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
