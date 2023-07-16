using Particle;
using UnityEngine;
using VehicleOption;

namespace Health
{
    public class HealthController : MonoBehaviour
    {
        private PlayerHealth playerHealth;
        [SerializeField] private PlayerHUD playerHUD;

        [SerializeField] private VehicleManager vehicleManager;
        [SerializeField] private CarBurst carBurst;
        [SerializeField] private VehicleOption.Plane plane;
        [SerializeField] private PlaneBurst planeBurst;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private ParticleSystemManager explosion;

        private void Awake()
        {
            playerHealth = new PlayerHealth();
            playerHealth.AddChangeObserver(playerHUD);

            playerHealth.AddDieObserver(vehicleManager);
            playerHealth.AddDieObserver(carBurst);
            playerHealth.AddDieObserver(plane);
            playerHealth.AddDieObserver(planeBurst);
            playerHealth.AddDieObserver(cameraManager);
            playerHealth.AddDieObserver(explosion);
        }

        public void SetMaxValue(int value) => playerHealth.Health = value;
        public void TakeDamage(int damageAmount) => playerHealth.Health -= damageAmount;
    }
}
