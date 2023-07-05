using UnityEngine;

namespace Vehicle
{
    public class SwitchVehicle : MonoBehaviour
    {
        [SerializeField] private VehicleManager vehicleManager;
        [Space]

        [SerializeField] private Car carInstance;
        [SerializeField] private Plane planeInstance;

        [Space]
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private GameObject planePrefab;

        private void Awake() => SwitchToPlane();

        public void SwitchToCar()
        {
            vehicleManager.SwitchStrategy(carInstance, planePrefab.transform);
            SwapPrefabToCar();
        }

        public void SwitchToPlane()
        {
            vehicleManager.SwitchStrategy(planeInstance, carPrefab.transform);
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
