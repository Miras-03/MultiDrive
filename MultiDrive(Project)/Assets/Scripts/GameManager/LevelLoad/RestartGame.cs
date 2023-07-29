using Health;
using UnityEngine;
using Zenject;

public sealed class RestartGame : MonoBehaviour, IDieableObserver
{
    private LevelManager levelManager;

    [Inject]
    public void Construct(LevelManager levelManager) => this.levelManager = levelManager;

    public void OnHealthOver() => levelManager.RestartScene();
}