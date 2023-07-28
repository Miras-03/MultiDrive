using UnityEngine;
using Health;

namespace VehicleOption
{
    public class CarExplosion : MonoBehaviour, IDieableObserver
    {
        [SerializeField] private GameObject[] skeletons;
        [SerializeField] private AudioSource skiddingSound;
        [SerializeField] private GameObject effects;

        public void OnHealthOver()
        {
            if (gameObject.activeSelf)
            {
                TurnOffEffects();
                ChangeSkeleton();
                TurnOffSounds();
            }
        }

        private void TurnOffEffects() => effects.SetActive(false);

        private void TurnOffSounds() => skiddingSound.enabled = false;

        private void ChangeSkeleton()
        {
            skeletons[0].SetActive(false);
            skeletons[1].SetActive(true);
        }
    }
}