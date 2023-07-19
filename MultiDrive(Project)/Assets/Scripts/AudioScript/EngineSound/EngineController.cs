using UnityEngine;
using Zenject;
using Health;

namespace Audio.Engine
{
    public class EngineController : MonoBehaviour, ISwitchable, IDieableObserver
    {
        [SerializeField] private CarEngine carEngine;
        [SerializeField] private PlaneEngine planeEngine;

        private IEngineSoundable engineSound;

        [Inject]
        public void Contruct(IEngineSoundable engineSound)
        {
            this.engineSound = engineSound;
            PlaySound(engineSound);
        }

        public void SwitchToCar() => SwitchSound(planeEngine, carEngine);
        public void SwitchToPlane() => SwitchSound(carEngine, planeEngine);

        public void SwitchSound(IEngineSoundable currentEngine, IEngineSoundable followingEngine)
        {
            engineSound = followingEngine;
            StopSound(currentEngine);
            PlaySound(engineSound);
        }

        public void OnHealthOver() => StopSound(engineSound);

        private void PlaySound(IEngineSoundable currentEngine) => currentEngine.Play();
        private void StopSound(IEngineSoundable currentEngine) => currentEngine.Stop();
    }
}