using UnityEngine;
using Health;

namespace VehicleOption
{
    public class CarBurst : MonoBehaviour, IDieableObserver
    {
        [SerializeField] private GameObject[] skeletons;
        [SerializeField] private GameObject smoke;

        public void OnHealthOver()
        {
            if (gameObject.activeSelf)
            {
                ChangeSkeleton();
                TurnOffMuffler();
            }
        }

        private void TurnOffMuffler() => smoke.SetActive(false);

        private void ChangeSkeleton()
        {
            skeletons[0].SetActive(false);
            skeletons[1].SetActive(true);
        }
    }
}