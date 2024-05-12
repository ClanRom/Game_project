using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "ScriptableObject/Create Weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldownAttack;
    [SerializeField] private float _range;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    public GameObject Prefab => _prefab;
    public float Damage => _damage;
    public float CoolDamage => _cooldownAttack;
    public float Range => _range;
    public Sprite Sprite => _sprite;
}
