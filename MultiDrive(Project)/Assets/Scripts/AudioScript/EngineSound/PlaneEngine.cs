using UnityEngine;
using System.Collections;

namespace Audio.Engine
{
    public class PlaneEngine : MonoBehaviour, IEngineSoundable
    {
        [SerializeField] private AudioSource engine;

        public void Play() => engine.Play();
        public void Stop() => engine.Stop();
    }
}