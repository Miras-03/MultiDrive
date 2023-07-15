using UnityEngine;
using VehicleOption;

namespace Health
{
    public class HealthController : MonoBehaviour
    {
        private PlayerHealth playerHealth;
        [SerializeField] private PlayerHUD playerHUD;

        [SerializeField] private VehicleManager vehicleManager;
        [SerializeField] private Car car;
        [SerializeField] private VehicleOption.Plane plane;
        [SerializeField] private CameraManager cameraManager;

        private void Awake()
        {
            playerHealth = new PlayerHealth();
            playerHealth.AddChangeObserver(playerHUD);

            playerHealth.AddDieObserver(vehicleManager);
            playerHealth.AddDieObserver(plane);
            playerHealth.AddDieObserver(car);
            playerHealth.AddDieObserver(cameraManager);
        }

        public void SetMaxValue(int value) => playerHealth.Health = value;
        public void TakeDamage(int damageAmount) => playerHealth.Health -= damageAmount;
    }
}
