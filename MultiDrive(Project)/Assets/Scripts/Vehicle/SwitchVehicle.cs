using Particle;
using UnityEngine;
using Zenject;

namespace VehicleOption
{
    public sealed class SwitchVehicle : MonoBehaviour
    {
        [SerializeField] private CameraManager cameraManager;

        [Inject] private ParticleSystemManager particleSystemManager;

        private VehicleManager vehicleManager;

        [Header("Vehicle intances")]
        [SerializeField] private Car carInstance;
        [SerializeField] private Plane planeInstance;

        [Space]
        [Header("Vehicle prefabs")]
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private GameObject planePrefab;

        private void Awake() => vehicleManager = GetComponent<VehicleManager>();

        private void Start() => StartVehicle();

        public void StartVehicle()
        {
            vehicleManager.SwitchVehicle(carInstance, planeInstance.transform);
            SwapPrefabToCar();

            cameraManager.MoveCameraCloser();
        }

        public void SwitchToCar()
        {
            vehicleManager.SwitchVehicle(carInstance, planeInstance.transform);
            particleSystemManager.PlayParticleSystem();
            SwapPrefabToCar();

            cameraManager.MoveCameraCloser();
        }

        public void SwitchToPlane()
        {
            vehicleManager.SwitchVehicle(planeInstance, carInstance.transform);
            particleSystemManager.PlayParticleSystem();
            SwapPrefabToPlane();

            cameraManager.MoveCameraAway();
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
