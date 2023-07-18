using UnityEngine;
using Zenject;
using Particle;

namespace Particle
{
    public class ParticleSystemInstaller : MonoInstaller
    {
        [SerializeField] private ParticleSystem particleSystemPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ParticleSystem>().FromInstance(particleSystemPrefab).AsSingle().NonLazy();
            Container.Bind<ParticleSystemManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}