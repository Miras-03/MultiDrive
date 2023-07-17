using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Health.HUD
{
    public class PlayerHUD : MonoBehaviour, IHealthObserver
    {
        [SerializeField] private HealthController healthController;

        private Slider healthBar;
        private const int maxValue = 100;
        private const float decreaseSpeed = 1.5f;

        private void Awake() => healthBar = GetComponent<Slider>();

        private void Start() => SetMaxValue(maxValue);

        public void SetMaxValue(int newHealth)
        {
            healthBar.maxValue = newHealth;
            healthController.SetMaxValue(newHealth);
        }

        public void OnHealthChanged(int newHealth) => StartCoroutine(SmoothDecreaseHealthBar(newHealth));

        private IEnumerator SmoothDecreaseHealthBar(int newHealth)
        {
            float currentHealth = healthBar.value;
            float targetHealth = newHealth;

            while (currentHealth > targetHealth)
            {
                currentHealth -= decreaseSpeed * Time.fixedDeltaTime;
                healthBar.value = currentHealth;
                yield return null;
            }

            healthBar.value = newHealth;
        }
    }
}