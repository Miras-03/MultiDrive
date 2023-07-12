using UnityEngine;

namespace VehicleOption
{
    [RequireComponent(typeof(VehicleManager))]
    public sealed class SwitchVehicle : MonoBehaviour
    {
        [SerializeField] private VehicleManager vehicleManager;

        [Header("Vehicle intances")]
        [SerializeField] private Car carInstance;
        [SerializeField] private Plane planeInstance;

        [Space]
        [Header("Vehicle prefabs")]
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private GameObject planePrefab;

        private void Awake() => SwitchToCar();

        public void SwitchToCar()
        {
            vehicleManager.SwitchVehicle(carInstance, planeInstance.transform);
            SwapPrefabToCar();
        }

        public void SwitchToPlane()
        {
            vehicleManager.SwitchVehicle(planeInstance, carInstance.transform);
            SwapPrefabToPlane();
        }

        private void SwapPrefabToCar()
        {
            carPrefab.SetActive(true);
            planePrefab.SetActive(false);
        }

        private void SwapPrefabToPlane()
        {
            planePrefab.SetActive(true);
            carPrefab.SetActive(false);
        }
    }
}
