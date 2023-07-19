using UnityEngine;
using Zenject;
using Health;
using System.Collections;

namespace Particle
{
    public sealed class ParticleSystemManager : MonoBehaviour, IDieableObserver, ISwitchable, ISoundable
    {
        [SerializeField] private AudioSource explosionSound;

        private ParticleSystem particle;

        [Inject]
        private void Construct(ParticleSystem particleSystem) => this.particle = particleSystem;

        public void PlayParticleSystem()
        {
            particle.Play();
            Sound(explosionSound);
        }

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

        public void Sound(AudioSource sound) => sound.Play();
    }
}