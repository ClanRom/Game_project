using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Create Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private uint _level;
    [SerializeField] private float _visionRadius;

    public float MaxHealth => _maxHealth;
    public float Speed => _speed;
    public uint Level => _level;
    public float VisionRadius => _visionRadius;
}
