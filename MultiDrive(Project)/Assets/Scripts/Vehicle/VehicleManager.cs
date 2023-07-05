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
            currentPosition.position = currentVehicle.transform.position;

            currentVehicle.Move();
            currentVehicle.Control();
        }

        public void SwitchStrategy(Vehicle vehicle, Transform previousPosition)
        {
            currentVehicle = vehicle;
            currentVehicle.transform.position = previousPosition.position;
        }
    }
}
