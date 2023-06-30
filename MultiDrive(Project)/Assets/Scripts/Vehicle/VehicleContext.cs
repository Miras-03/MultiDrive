using UnityEngine;

namespace DesignPatterns.Strategy
{
    public class VehicleContext : MonoBehaviour
    {
        public IVehicleStrategy currentStrategy;
        private GameObject currentPrefab;

        public void SwitchStrategy(IVehicleStrategy strategy, GameObject prefab)
        {
            currentStrategy = strategy;
            currentPrefab = prefab;
        }

        public void Move() => currentStrategy.Move();

        public GameObject CurrentPrefab
        {
            get => currentPrefab; 
        }
    }
}
