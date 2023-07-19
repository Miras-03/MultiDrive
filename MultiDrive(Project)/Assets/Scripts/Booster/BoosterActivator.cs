using UnityEngine;
using Zenject;
using Tunel;

namespace Booster
{
    public sealed class BoosterActivator : MonoBehaviour, ISoundable
    {
        [Inject]
        private IEnhancable enhance;

        [SerializeField] private TunelController tunelController;
        [SerializeField] private AudioSource activationSound;

        private void Start() => tunelController.TurnRotateOff();

        private void OnTriggerEnter()
        {
            Sound(activationSound);
            enhance.ActivateForce();
            tunelController.TurnRotateOn();
        }

        public void Sound(AudioSource sound) => sound.Play();
    }
}