using Health;
using UnityEngine;

namespace VehicleOption
{
    public class VehicleManager : MonoBehaviour, IDieableObserver
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

        public void OnHealthOver() => Destroy(gameObject);
    }
}
