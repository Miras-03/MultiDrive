using UnityEngine;
using System.Collections;

namespace Particle
{
    public class Confetti : MonoBehaviour
    {
        [SerializeField] private ParticleSystem confetti;

        private void OnTriggerEnter() => StartCoroutine(PlayParticle());

        private IEnumerator PlayParticle()
        {
            yield return new WaitForSeconds(1.5f);
            confetti.Play();
        }
    }
}