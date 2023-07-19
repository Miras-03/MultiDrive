using UnityEngine;
using Zenject;
using Audio.Engine;

public class EngineInstaller : MonoInstaller
{
    [SerializeField] private CarEngine carEngine;

    public override void InstallBindings()
    {
        Container.Bind<IEngineSoundable>().FromInstance(carEngine).AsSingle().NonLazy();
        Container.Bind<EngineController>().FromComponentInChildren().AsSingle();
    }
}