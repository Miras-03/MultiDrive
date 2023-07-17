using UnityEngine;
using UnityEngine.UI;

namespace Health.HUD
{
    public class ChangeColorOfPlayerHUD : MonoBehaviour, IHealthObserver
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private Gradient healthBarColorGradient;

        private Slider healthBar;

        private const int maxValue = 100;

        private void Awake() => healthBar = GetComponent<Slider>();

        private void Start() => SetStartHealthBarColor();

        public void OnHealthChanged(int newHealth)
        {
            float normalizedHealth = (float)newHealth / (float)maxValue;
            Color healthColor = healthBarColorGradient.Evaluate(normalizedHealth);
            healthBar.fillRect.GetComponent<Image>().color = healthColor;
        }

        private void SetStartHealthBarColor()
        {
            Color healthColor = healthBarColorGradient.Evaluate(1);
            healthBar.fillRect.GetComponent<Image>().color = healthColor;
        }
    }
}