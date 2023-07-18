using UnityEngine;
using VehicleOption;
using System.Collections;

namespace VehicleOption
{
    public sealed class StopEngine : MonoBehaviour
    {
        [SerializeField] private Car car;
        [SerializeField] private VehicleManager vehicleManager;
        [SerializeField] private ParticleSystem smoke;

        private void OnTriggerEnter()
        {
            SlowSpeedDown();
            StartCoroutine(BreakDownEngine());
        }

        private void SlowSpeedDown() => car.moveSpeed = 5f;

        private IEnumerator BreakDownEngine()
        {
            yield return new WaitForSeconds(5f);
            TurnOffVehicleManager();
            TurnOffSmoke();
        }

        private void TurnOffVehicleManager() => vehicleManager.enabled = false;

        private void TurnOffSmoke() => smoke.Stop();
    }
}