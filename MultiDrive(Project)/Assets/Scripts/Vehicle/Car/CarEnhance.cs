using UnityEngine;

namespace VehicleOption
{
    public sealed class CarEnhance : MonoBehaviour, IEnhancable
    {
        private Rigidbody rb;
        private const float forceNewton = CarData.forceNewton;

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void ActivateForce() => rb.AddForce(transform.forward * forceNewton, ForceMode.VelocityChange);
    }
}