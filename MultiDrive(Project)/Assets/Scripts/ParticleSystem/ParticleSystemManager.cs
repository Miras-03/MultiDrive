using UnityEngine;
using Zenject;
using Health;
using System.Collections;

namespace Particle
{
    public class ParticleSystemManager : MonoBehaviour, IDieableObserver, ISwitchable
    {   
        private ParticleSystem particle;

        [Inject]
        private void Construct(ParticleSystem particleSystem) => this.particle = particleSystem;

        public void PlayParticleSystem() => particle.Play();

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

        public void SwitchToCar() => PlayParticleSystem();
        public void SwitchToPlane() => PlayParticleSystem();
    }
}