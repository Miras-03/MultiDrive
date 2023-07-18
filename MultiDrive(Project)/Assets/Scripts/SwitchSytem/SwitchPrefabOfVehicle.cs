using UnityEngine;

namespace SwitchOption
{
    public sealed class SwitchPrefabOfVehicle : MonoBehaviour, ISwitchable
    {
        [Header("Vehicle prefabs")]
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private GameObject planePrefab;

        private void Start() => SwitchToCar();

        public void SwitchToCar() => SwapPrefabToCar();
        public void SwitchToPlane() => SwapPrefabToPlane();

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
