using UnityEngine;
using Health;

namespace VehicleOption
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : Vehicle, IEnhancable
    {
        [SerializeField] private Transform centerOfGravity;
        [SerializeField] private HealthController healthController;

        [SerializeField] private FloatingJoystick floatingJoystick;

        private const float moveSpeed = CarData.carSpeed;
        private const float maxSpeed = CarData.maxSpeed;
        private const float drag = CarData.drag;
        private const float steerAngle = CarData.steerAngle;
        private const float forceNewton = CarData.forceNewton;
        private const float smoothSpeed = CarData.smoothSpeed;

        private const int damageValue = 5;

        private float steerInput;

        private Vector3 moveForce;
        private Rigidbody rb;

        private void Awake() => rb = GetComponent<Rigidbody>();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfGravity.localPosition;
        }

        private void OnEnable() => ResetProperties();

        public void ActivateForce() => rb.AddForce(transform.forward * forceNewton, ForceMode.Impulse);

        public void ResetProperties()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public override void Move()
        {
            moveForce += transform.forward * moveSpeed * Time.fixedDeltaTime;
            transform.position += moveForce * Time.fixedDeltaTime;
            Drag();
        }

        public override void Control()
        {
            steerInput = floatingJoystick.Horizontal * smoothSpeed;
            transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.fixedDeltaTime);
        }

        private void Drag()
        {
            moveForce *= drag;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.CompareTag("Barrier"))
                healthController.TakeDamage(damageValue);
        }
    }
}