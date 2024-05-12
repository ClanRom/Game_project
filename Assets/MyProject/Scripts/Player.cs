using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Motion _motion;
    [SerializeField] private Attacker _attack;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerSO _playerSO;
    private float _speed => _playerSO.Speed;
    private float _maxHealth => _playerSO.MaxHealth;

    private bool IsMoving => _inputManager.Motion.sqrMagnitude > 0.005f;

    private void Start() => _health.SetHealth(_maxHealth);
    private void Update()
    {
        if (_attack.CanAttack && _inputManager.Attacking)
        {
            _attack.Attack();
        }
        
        if (!_attack.IsAttacking)
            _motion.ProcessMoving(IsMoving, _inputManager.Motion, _speed);
    }
}
