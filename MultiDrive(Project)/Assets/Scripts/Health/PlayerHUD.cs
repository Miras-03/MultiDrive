using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class PlayerHUD : MonoBehaviour, IHealthObserver
    {
        [SerializeField] private HealthController healthController;

        private Slider healthBar;
        private const int maxValue = 100;

        private void Awake() => healthBar = GetComponent<Slider>();
        private void Start()
        {
            SetMaxValue(maxValue);
            healthController.SetMaxValue(maxValue);
        }

        public void SetMaxValue(int newHealth) => healthBar.maxValue = newHealth;
        public void OnHealthChanged(int newHealth) => healthBar.value = newHealth;
    }
}