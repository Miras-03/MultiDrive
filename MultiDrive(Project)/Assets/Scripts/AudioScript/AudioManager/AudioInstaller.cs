using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioManager audioManagerPrefab;

    public override void InstallBindings() =>
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle();
}
