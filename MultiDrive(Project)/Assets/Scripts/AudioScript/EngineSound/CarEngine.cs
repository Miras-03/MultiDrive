using UnityEngine;
using System.Collections;

namespace Audio.Engine
{
    public class CarEngine : MonoBehaviour, IEngineSoundable
    {
        [SerializeField] private AudioSource engine;
        [SerializeField] private AudioSource engineLaunch;

        public void Play()
        {
            engineLaunch.Play();
            StartCoroutine(PlayEngine());
        }
        public void Stop() => engine.Stop();

        private IEnumerator PlayEngine()
        {
            yield return new WaitForSeconds(0.5f);
            engine.Play();
        }
    }
}