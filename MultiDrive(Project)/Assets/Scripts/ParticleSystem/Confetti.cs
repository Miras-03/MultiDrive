using UnityEngine;
using System.Collections;

namespace Particle
{
    public sealed class Confetti : MonoBehaviour, IFinishObserver
    {
        [SerializeField] private ParticleSystem confetti;

        public void Execute() => StartCoroutine(PlayParticle());

        private IEnumerator PlayParticle()
        {
            yield return new WaitForSeconds(1.5f);
            confetti.Play();
        }
    }
}