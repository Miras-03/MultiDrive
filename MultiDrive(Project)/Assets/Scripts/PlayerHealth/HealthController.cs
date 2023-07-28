using Particle;
using UnityEngine;
using VehicleOption;
using Health.HUD;
using CameraOption;
using Audio.Engine;

namespace Health
{
    public sealed class HealthController : MonoBehaviour
    {
        private PlayerHealth playerHealth;

        [Header("Changable Observers")]
        [SerializeField] private PlayerHUD playerHUD;
        [SerializeField] private ChangeColorOfPlayerHUD changeColorOfPlayerHUD;
        [SerializeField] private HUDShake hudShake;

        [Space(20)]
        [Header("Diable Observers")]
        [SerializeField] private VehicleManager vehicleManager;
        [SerializeField] private CarExplosion carExplosion;
        [SerializeField] private CarDamage carDamage;
        [SerializeField] private VehicleOption.Plane plane;
        [SerializeField] private PlaneExplosion planeExplosion;
        [SerializeField] private PlaneDamage planeDamage;
        [SerializeField] private EngineController engineController;
        [SerializeField] private ParticleSystemManager explosion;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private RestartGame restartGame;

        private void Awake()
        {
            playerHealth = new PlayerHealth();

            playerHealth.AddChangeObserver(playerHUD);
            playerHealth.AddChangeObserver(changeColorOfPlayerHUD);
            playerHealth.AddChangeObserver(hudShake);

            playerHealth.AddDieableObserver(vehicleManager);
            playerHealth.AddDieableObserver(carExplosion);
            playerHealth.AddDieableObserver(carDamage);
            playerHealth.AddDieableObserver(plane);
            playerHealth.AddDieableObserver(planeExplosion);
            playerHealth.AddDieableObserver(planeDamage);
            playerHealth.AddDieableObserver(engineController);
            playerHealth.AddDieableObserver(explosion);
            playerHealth.AddDieableObserver(cameraManager);
            playerHealth.AddDieableObserver(restartGame);
        }

        public void SetMaxValue(int value) => playerHealth.Health = value;
        public void TakeDamage(int damageAmount) => playerHealth.Health -= damageAmount;
    }
}
