using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _healthPoint;
    


    private void Start()
    {
        _slider.value = _player.Health;
        _healthPoint.text = _player.Health.ToString();
        
    }

    
    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _player.Die += OnDie;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
        _player.Die -= OnDie;
    }
    

    public void OnHealthChanged(int health)
    {
        _slider.value = health;
        _healthPoint.text = health.ToString();
    }

    public void OnDie()
    {
        Destroy(_player.gameObject);
    }
}
