using UnityEngine;

namespace Tunel
{
    public sealed class BarrierController : MonoBehaviour
    {
        private BarrierRotate tunel;

        private void Awake() => tunel = GetComponent<BarrierRotate>();

        public void TurnRotateOn() => tunel.enabled = true;

        public void TurnRotateOff() => tunel.enabled = false;
    }
}