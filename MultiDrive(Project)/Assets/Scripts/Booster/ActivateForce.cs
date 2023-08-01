using UnityEngine;
using Zenject;
using Tunel;
using VehicleOption;

namespace Booster
{
    public sealed class ActivateForce : MonoBehaviour
    {
        [Inject]
        private IEnhancable enhance;

        [SerializeField] private BarrierController tunelController;

        private void Start() => tunelController.TurnRotateOff();

        private void OnTriggerEnter()
        {
            enhance.ActivateForce();
            tunelController.TurnRotateOn();
        }
    }
}