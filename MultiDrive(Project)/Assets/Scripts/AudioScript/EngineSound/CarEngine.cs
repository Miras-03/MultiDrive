using UnityEngine;
using System.Collections;
using VehicleOption;

namespace Audio.Engine
{
    public class CarEngine : MonoBehaviour, IEngineSoundable
    {
        [SerializeField] private Car car;
        [SerializeField] private AudioSource engine;
        [SerializeField] private AudioSource engineLaunch;

        private const float minPitch = 0.5f;
        private const float maxPitch = 2.5f;

        private float pitch;

        private const float minSpeed = 0f;
        private const float maxSpeed = 60f;
        private const float waitTime = 0.5f;

        public void Play()
        {
            engineLaunch.Play();
            StartCoroutine(PlayEngine());
        }

        public void Stop() => engine.Stop();

        private IEnumerator PlayEngine()
        {
            yield return new WaitForSeconds(waitTime);
            engine.Play();
        }

        private void FixedUpdate()
        {
            float currentSpeed = car.moveSpeed;
            float normalizedSpeed = Mathf.InverseLerp(minSpeed, maxSpeed, currentSpeed);
            pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);
            engine.pitch = pitch;
        }
    }
}
