using UnityEngine;
using Health;

namespace VehicleOption
{
    public class PlaneBurst : MonoBehaviour, IDieableObserver
    {
        [SerializeField] private Material[] materials;
        [SerializeField] private GameObject muffler;

        private Rigidbody rb;

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void OnHealthOver()
        {
            TurnOffEngine();
            TurnOffMuffler();
            ChangeColor();
            Destroy(this);
        }

        private void ChangeColor()
        {
            foreach (Material material in materials)
                material.color = Color.black;
        }

        private void TurnOffMuffler() => muffler?.SetActive(false);

        private void TurnOffEngine() => rb.useGravity = true;
    }
}