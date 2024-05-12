using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image _imageHealth;
    private Health _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>().GetComponent<Health>();
        _player.OnDamaged += OnDamaged;
    }

    private void OnDamaged(Health health) => _imageHealth.fillAmount = health.CurrentHealth / health.MaxHealth;

    private void OnDisable() => _player.OnDamaged += OnDamaged;
}
