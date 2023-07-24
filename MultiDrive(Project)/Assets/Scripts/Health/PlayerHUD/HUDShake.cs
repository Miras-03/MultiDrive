using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Health.HUD
{
    public class HUDShake : MonoBehaviour, IHealthObserver
    {
        private Slider healthBar;

        private const float shakeDuration = 5f;
        private const float shakeIntensity = 5f;

        private bool isReady = false;

        private Vector3 originalHealthBarPosition;

        private void Awake()
        {
            healthBar = GetComponent<Slider>();
            originalHealthBarPosition = healthBar.transform.localPosition;
        }

        public void OnHealthChanged(int newHealth)
        {
            if (isReady)
                StartCoroutine(ShakeHealthBar());
            else
                isReady = true;
        }

        private IEnumerator ShakeHealthBar()
        {
            float elapsedTime = 0f;

            while (elapsedTime < shakeDuration)
            {
                float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
                float offsetY = Random.Range(-1f, 1f) * shakeIntensity;

                healthBar.transform.localPosition = originalHealthBarPosition + new Vector3(offsetX, offsetY, 0f);

                elapsedTime += Time.fixedDeltaTime;
                yield return null;
            }

            healthBar.transform.localPosition = originalHealthBarPosition;
        }
    }
}