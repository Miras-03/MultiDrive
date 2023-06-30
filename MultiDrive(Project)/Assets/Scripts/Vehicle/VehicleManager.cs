using UnityEngine;

public enum VehicleType
{
    Car, 
    Plane
}

namespace DesignPatterns.Strategy
{
    [RequireComponent(typeof(VehicleContext))]
    public class VehicleManager : MonoBehaviour
    {
        [SerializeField] private VehicleContext vehicle;
        [SerializeField] private VehicleData vehicleData;
        [SerializeField] private VehicleType vehicleType = VehicleType.Plane;

        private void Awake()
        {
            vehicle = GetComponent<VehicleContext>();
        }

        private void Start()
        {
            SetVehiclePrefab();
            vehicle.SwitchStrategy(new PlaneStrategy(), vehicleData.planePrefab);
        }

        private void Update()
        {
            HandleInput();
            vehicle.Move();
            //if(Input.GetMouseButtonDown(0)) 
                //SetCarPrefab();
        }

        public void HandleInput()
        {
            switch (vehicleType)
            {
                case VehicleType.Plane:
                    vehicle.SwitchStrategy(new CarStrategy(), vehicleData.carPrefab);
                    break;
                case VehicleType.Car:
                    vehicle.SwitchStrategy(new PlaneStrategy(), vehicleData.planePrefab);
                    break;
                default:
                    break;
            }
        }

        private void SetVehiclePrefab()
        {
            vehicleData.carPrefab = Instantiate(vehicleData.carPrefab, transform.position, transform.rotation);
            vehicleData.planePrefab = Instantiate(vehicleData.planePrefab, transform.position, transform.rotation);
        }
        /*private void SetCarPrefab()
        {
            vehicleData.carPrefab = Instantiate(vehicleData.carPrefab, transform.position, transform.rotation);
            Destroy(vehicleData.planePrefab);
        }*/
    }
}

