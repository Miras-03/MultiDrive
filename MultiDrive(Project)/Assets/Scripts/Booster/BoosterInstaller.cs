using UnityEngine;
using VehicleOption;
using Booster;
using Zenject;

public class BoosterInstaller : MonoInstaller
{
    [SerializeField] private VehicleOption.Car car;

    public override void InstallBindings()
    {
        Container.Bind<IEnhancable>().FromInstance(car).AsSingle().NonLazy();
        Container.Bind<ActivateForce>().FromComponentInChildren().AsSingle();
    }
}