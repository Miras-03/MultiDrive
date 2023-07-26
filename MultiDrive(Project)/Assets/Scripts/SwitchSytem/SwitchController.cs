using UnityEngine;
using Audio.Engine;
using Particle;

namespace SwitchOption
{
    public class SwitchController : MonoBehaviour
    {
        private Switcher switchVehicleProperties;

        [Header("SwitchObservers")]
        [SerializeField] private SwitchVehicle switchVehicle;
        [SerializeField] private SwitchPrefabOfVehicle switchPrefabOfVehicle;
        [SerializeField] private ParticleSystemManager particleSystemManager;
        [SerializeField] private EngineController engineController;

        private void Awake()
        {
            switchVehicleProperties = new Switcher();

            switchVehicleProperties.AddSwitchObservers(switchVehicle);
            switchVehicleProperties.AddSwitchObservers(switchPrefabOfVehicle);
            switchVehicleProperties.AddSwitchObservers(particleSystemManager);
            switchVehicleProperties.AddSwitchObservers(engineController);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car"))
                SwitchPlaneProperty();
            else
                SwitchCarProperty();

            gameObject.SetActive(false);
        }

        private void SwitchCarProperty() => switchVehicleProperties.NotifyCarObservers();
        private void SwitchPlaneProperty() => switchVehicleProperties.NotifyPlaneObservers();
    }
}