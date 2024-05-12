using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private WeaponSO _weaponSO;

    public bool IsAttacking = false;

    private float _cooldownAttack => _weaponSO.CoolDamage;
    private float _damage => _weaponSO.Damage;
    private Collider[] _hits = new Collider[3];

    public bool CanAttack => _cooldownTimer <= 0;
    public float RangeAttack => _weaponSO.Range;

    private float _cooldownTimer;
    void Start() => ResetAttackTimer();

    void Update() => _cooldownTimer -= Time.deltaTime;

    public void Attack()
    {
        IsAttacking = true;
        AnimateAttack();
        ResetAttackTimer();
    }

    public void AttackEvent() => AttackOfTarget();

    public void EndAttacking() => IsAttacking = false;

    private void ResetAttackTimer() => _cooldownTimer = _cooldownAttack;

    private void AttackOfTarget()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, RangeAttack, _hits, _layerMask);

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
        Gizmos.DrawWireSphere(transform.position, RangeAttack);
    }
}
