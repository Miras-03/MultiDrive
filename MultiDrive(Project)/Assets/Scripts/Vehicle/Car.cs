using UnityEngine;

namespace VehicleOption
{
    public class Car : Vehicle, IEnhancable
    {
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private Transform forwardOfGravity;

        private const float moveSpeed = CarData.carSpeed;
        private const float maxSpeed = CarData.maxSpeed;
        private const float drag = CarData.drag;
        private const float steerAngle = CarData.steerAngle;
        private const float forceNewton = CarData.forceNewton;
        private const float smoothSpeed = CarData.smoothSpeed;

        private float steerInput;

        private Vector3 moveForce;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = forwardOfGravity.localPosition;
        }

        public void ActivateForce() => rb.AddForce(transform.forward * forceNewton, ForceMode.Impulse);

        public override void Move()
        {
            moveForce += transform.forward * moveSpeed * Time.fixedDeltaTime;
            transform.position += moveForce * Time.fixedDeltaTime;
            Drag();
        }

        public override void Control()
        {
            steerInput = joystick.Horizontal * smoothSpeed;
            transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.fixedDeltaTime);
        }

        private void Drag()
        {
            moveForce *= drag;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }
    }
}