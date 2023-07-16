using UnityEngine;
using Health;

namespace VehicleOption
{
    public class PlaneBurst : MonoBehaviour, IDieableObserver
    {
        [SerializeField] private GameObject[] skeletons;
        [SerializeField] private GameObject smoke;

        private Rigidbody rb;

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void OnHealthOver()
        {
            if (gameObject.activeSelf)
            {
                TurnOffEngine();
                TurnOffMuffler();
                ChangeSkeleton();
                Destroy(this);
            }
        }

        private void ChangeSkeleton()
        {
            skeletons[0].SetActive(false);
            skeletons[1].SetActive(true);
        }

        private void TurnOffMuffler() => smoke?.SetActive(false);

        private void TurnOffEngine() => rb.useGravity = true;
    }
}