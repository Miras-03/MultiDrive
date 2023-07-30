using Particle;
using UnityEngine;
using VehicleOption;

public sealed class FinishController : MonoBehaviour
{
    private FinishTrigger finishTrigger;

    [Space(20)]
    [Header("Finish observers")]
    [SerializeField] private EnableFinishPanel enableIcons;
    [SerializeField] private Confetti confetti;
    [SerializeField] private Congratulate congratulate;
    [SerializeField] private StopEngine stopEngine;
    [SerializeField] private OpenCurrentLevel openCurrentLevel;
    [SerializeField] private DisableHUD disableHUD;

    private void Awake()
    {
        finishTrigger = new FinishTrigger();

        finishTrigger.AddObservers(enableIcons);
        finishTrigger.AddObservers(congratulate);
        finishTrigger.AddObservers(confetti);
        finishTrigger.AddObservers(stopEngine);
        finishTrigger.AddObservers(openCurrentLevel);
        finishTrigger.AddObservers(disableHUD);
    }

    private void OnTriggerEnter() => finishTrigger.NotifyObserversAboutFinish();
}