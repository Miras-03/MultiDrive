using Particle;
using UnityEngine;

namespace SwitchOption
{
    public class SwitchController : MonoBehaviour
    {
        private Switcher switchVehicleProperties;

        [SerializeField] private SwitchCamera switchCamera;
        [SerializeField] private SwitchVehicle switchVehicle;
        [SerializeField] private SwitchPrefabOfVehicle switchPrefabOfVehicle;
        [SerializeField] private ParticleSystemManager particleSystemManager;

        private void Awake()
        {
            switchVehicleProperties = new Switcher();

            switchVehicleProperties.AddSwitchObservers(switchCamera);
            switchVehicleProperties.AddSwitchObservers(switchVehicle);
            switchVehicleProperties.AddSwitchObservers(switchPrefabOfVehicle);
            switchVehicleProperties.AddSwitchObservers(particleSystemManager);
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