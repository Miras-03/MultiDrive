using UnityEngine;

namespace Vehicle
{
    public class VehicleManager : MonoBehaviour
    {
        private Vehicle currentVehicle;

        private void Awake()
        { 
            currentVehicle = GetComponent<Vehicle>();
            currentVehicle = new Plane(gameObject.transform);
        }

        private void FixedUpdate() => currentVehicle.Move();

        public void SwitchStrategy(Vehicle vehicle) => currentVehicle = vehicle;
    }
}
