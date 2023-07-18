using UnityEngine;
using Zenject;
using Particle;
using VehicleOption;

namespace SwitchOption
{
    public sealed class SwitchVehicle : MonoBehaviour, ISwitchable
    {
        private VehicleManager vehicleManager;

        [Header("Vehicle intances")]
        [SerializeField] private Car carInstance;
        [SerializeField] private VehicleOption.Plane planeInstance;

        private void Awake() => vehicleManager = GetComponent<VehicleManager>();

        private void Start() => SwitchToCar();

        public void SwitchToCar() => vehicleManager.SwitchVehicle(carInstance, planeInstance.transform);

        public void SwitchToPlane() => vehicleManager.SwitchVehicle(planeInstance, carInstance.transform);
    }
}
