using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private Camera cam;
    private Health health;

    public void Init(Health health)
    {
        this.health = health;
        slider.maxValue = health.HealthPoints;
        slider.value = health.HealthPoints;
        health.OnHealthChanged += OnHealthChanged;
    }
    
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        gameObject.transform.LookAt(cam.transform);
    }

    private void OnHealthChanged(int amount)
    {
        slider.value = amount;
    }

    private void OnDestroy()
    {
        health.OnHealthChanged -= OnHealthChanged;
    }
}
