using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Motion _motion;
    [SerializeField] private Attacker _attack;
    [SerializeField] private Health _health;

    private bool IsMoving => _inputManager.Motion.sqrMagnitude > 0.005f;

    private void Update()
    {
        if (_attack.CanAttack && _inputManager.Attacking)
        {
            _attack.Attack();
        }

        _motion.ProcessMoving(IsMoving, _inputManager.Motion);
    }
}
