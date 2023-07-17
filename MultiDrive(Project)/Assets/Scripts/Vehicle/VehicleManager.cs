using UnityEngine;
using Zenject;
using Health;

namespace VehicleOption
{
    public class VehicleManager : MonoBehaviour, IDieableObserver
    {
        private Vehicle currentVehicle;

        [HideInInspector] public Transform currentPosition;

        [Inject]
        public void Construct(Vehicle vehicle) => currentVehicle = vehicle;

        private void Awake() => currentPosition = GetComponent<Transform>();

        private void FixedUpdate()
        {
            currentPosition.SetPositionAndRotation(currentVehicle.transform.position, currentVehicle.transform.rotation);

            currentVehicle.Move();
            currentVehicle.Control();
        }

        public void SwitchVehicle(Vehicle vehicle, Transform previousTransform)
        {
            currentVehicle = vehicle;
            currentVehicle.transform.position = previousTransform.position;
        }

        public void OnHealthOver() => Destroy(this);
    }
}
