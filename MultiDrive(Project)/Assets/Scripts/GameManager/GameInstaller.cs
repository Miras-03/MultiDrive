using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
}