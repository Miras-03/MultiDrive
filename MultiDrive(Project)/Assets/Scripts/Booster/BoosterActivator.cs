using UnityEngine;
using Zenject;
using Tunel;

namespace Booster
{
    public sealed class BoosterActivator : MonoBehaviour
    {
        [Inject]
        private IEnhancable enhance;

        [SerializeField] private TunelController tunelController;

        private void Start() => tunelController.TurnRotateOff();

        private void OnTriggerEnter()
        {
            enhance.ActivateForce();
            tunelController.TurnRotateOn();
        }
    }
}