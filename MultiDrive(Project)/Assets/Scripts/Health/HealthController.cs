using Particle;
using UnityEngine;
using VehicleOption;
using Health.HUD;

namespace Health
{
    public class HealthController : MonoBehaviour
    {
        private PlayerHealth playerHealth;
        [SerializeField] private PlayerHUD playerHUD;
        [SerializeField] private ChangeColorOfPlayerHUD changeColorOfPlayerHUD;
        [SerializeField] private HUDShake hudShake;

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
            playerHealth.AddChangeObserver(changeColorOfPlayerHUD);
            playerHealth.AddChangeObserver(hudShake);

            playerHealth.AddDieableObserver(vehicleManager);
            playerHealth.AddDieableObserver(carBurst);
            playerHealth.AddDieableObserver(plane);
            playerHealth.AddDieableObserver(planeBurst);
            playerHealth.AddDieableObserver(cameraManager);
            playerHealth.AddDieableObserver(explosion);
        }

        public void SetMaxValue(int value) => playerHealth.Health = value;
        public void TakeDamage(int damageAmount) => playerHealth.Health -= damageAmount;
    }
}
