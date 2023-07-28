using UnityEngine;
using System.Collections;

namespace VehicleOption
{
    public sealed class StopEngine : MonoBehaviour, ISpeedChanger, IFinishObserver
    {
        [SerializeField] private Car car;
        [SerializeField] private VehicleManager vehicleManager;

        private const float lowSpeed = 5f;

        public void Execute()
        {
            ChangeSpeed(lowSpeed);
            DisableSmoke();
            StartCoroutine(BreakDownEngine());
        }

        private IEnumerator BreakDownEngine()
        {
            yield return new WaitForSeconds(lowSpeed);
            TurnOffVehicleManager();
        }

        private void TurnOffVehicleManager() => vehicleManager.enabled = false;

        public void ChangeSpeed(float speed) => car.maxSpeed = speed;
        
        private void DisableSmoke() => car.IsFinished = true;
    }
}