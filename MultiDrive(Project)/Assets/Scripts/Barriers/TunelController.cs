using UnityEngine;

namespace Tunel
{
    public sealed class TunelController : MonoBehaviour
    {
        private Tunel tunel;

        private void Awake() => tunel = GetComponent<Tunel>();

        public void TurnRotateOn() => tunel.enabled = true;

        public void TurnRotateOff() => tunel.enabled = false;
    }
}