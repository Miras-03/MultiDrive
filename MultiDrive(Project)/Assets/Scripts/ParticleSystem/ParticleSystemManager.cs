using UnityEngine;
using Zenject;

namespace Particle
{
    public class ParticleSystemManager : MonoBehaviour
    {   
        private ParticleSystem particleSystem;

        [Inject]
        private void Construct(ParticleSystem particleSystem) => this.particleSystem = particleSystem;

        public void PlayParticleSystem() => particleSystem.Play();
    }
}