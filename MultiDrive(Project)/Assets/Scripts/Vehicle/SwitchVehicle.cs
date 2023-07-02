using UnityEngine;

namespace Vehicle
{
    public class SwitchVehicle : MonoBehaviour
    {
        [SerializeField] private VehicleManager vehicleManager;
        [Space]
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private GameObject planePrefab;

        private void Awake()
        {
            vehicleManager = GetComponent<VehicleManager>();
        }

        private void Start() => SwitchToPlane();

        public void SwitchToCar()
        {
            vehicleManager.SwitchStrategy(new Car(gameObject.transform));
            SwapPrefabToCar();
        }

        public void SwitchToPlane()
        {
            vehicleManager.SwitchStrategy(new Plane(gameObject.transform));
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
