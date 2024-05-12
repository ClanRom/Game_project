using UnityEngine;

[CreateAssetMenu(fileName = "New Player Class", menuName = "ScriptableObject/Create Player Class")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speed;

    public float MaxHealth => _maxHealth;
    public float Speed => _speed;
}
