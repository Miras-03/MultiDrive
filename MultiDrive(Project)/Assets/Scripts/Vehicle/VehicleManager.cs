using UnityEngine;

namespace Vehicle
{
    public class VehicleManager : MonoBehaviour
    {
        private Vehicle currentVehicle;

        [HideInInspector] public Transform currentPosition;

        private void Awake()
        {
            currentVehicle = GetComponent<Vehicle>();
            currentPosition = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            currentPosition.SetPositionAndRotation(currentVehicle.transform.position, currentVehicle.transform.rotation);

            currentVehicle.Move();
            currentVehicle.Control();
        }

        public void SwitchVehicle(Vehicle vehicle, Transform previousTransform)
        {
            currentVehicle = vehicle;

            currentVehicle.transform.SetPositionAndRotation(previousTransform.position, previousTransform.rotation);
        }
    }
}
