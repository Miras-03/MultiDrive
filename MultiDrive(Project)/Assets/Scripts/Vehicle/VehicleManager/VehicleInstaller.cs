using UnityEngine;
using Zenject;
using VehicleOption;

public class VehicleInstaller : MonoInstaller
{
    [SerializeField] private Car car;

    public override void InstallBindings()
    {
        Container.Bind<Vehicle>().FromInstance(car).AsSingle().NonLazy();
        Container.Bind<VehicleManager>().FromComponentInChildren().AsSingle();
    }
}