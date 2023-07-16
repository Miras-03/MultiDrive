using UnityEngine;
using Zenject;
using Health;
using System.Collections;

namespace Particle
{
    public class ParticleSystemManager : MonoBehaviour, IDieableObserver
    {   
        private ParticleSystem particleSystem;

        [Inject]
        private void Construct(ParticleSystem particleSystem) => this.particleSystem = particleSystem;

        public void PlayParticleSystem() => particleSystem.Play();

        public void OnHealthOver()
        {
            PlayParticleSystem();
            DestroyParticleSystem();
        }

        IEnumerator DestroyParticleSystem()
        {
            yield return null;
            Destroy(gameObject);
        }
    }
}