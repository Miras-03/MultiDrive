using UnityEngine;

namespace Particle
{
    public class Confetti : MonoBehaviour
    {
        [SerializeField] private ParticleSystem confetti;

        private void OnTriggerEnter() => confetti.Play();
    }
}