using UnityEngine;

namespace VehicleOption
{
    public sealed class VehicleTransformation : MonoBehaviour
    {
        [SerializeField] private SwitchVehicle switchVehicle;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Car"))
                switchVehicle.SwitchToPlane();
            else
                switchVehicle.SwitchToCar();

            gameObject.SetActive(false);
        }
    }
}
