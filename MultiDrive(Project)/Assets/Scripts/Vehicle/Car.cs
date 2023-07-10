using UnityEngine;

namespace Vehicle
{ 
    public class Car : Vehicle, IEnhancable
    {
        [SerializeField] private FloatingJoystick joystick;

        [Space]
        [Header("Wheel colliders")]
        [SerializeField] private WheelCollider frontLeftWheelCollider;
        [SerializeField] private WheelCollider frontRightWheelCollider;
        [SerializeField] private WheelCollider backLeftWheelCollider;
        [SerializeField] private WheelCollider backRightWheelCollider;

        [Space]
        [Header("Wheel transforms")]
        [SerializeField] private Transform frontLeftWheelTransform;
        [SerializeField] private Transform frontRightWheelTransform;
        [SerializeField] private Transform backLeftWheelTransform;
        [SerializeField] private Transform backRightWheelTransform;

        public Rigidbody rb;

        private const float carSpeed = CarData.carSpeed;
        private const float motorForce = CarData.motorForce;
        private const float maxSteerAngle = CarData.maxSteerAngle;

        private float horizontalInput;

        private float currentSteerAngle;
        private float currentbreakForce;

        private void Start() => rb = GetComponent<Rigidbody>();

        public override void Move()
        {
            HandleSteering();
            UpdateWheels();
            HandleMotor();
        }

        public override void Control() => horizontalInput = joystick.Horizontal;

        private void HandleMotor()
        {
            frontLeftWheelCollider.motorTorque = carSpeed * motorForce * Time.fixedDeltaTime;
            frontRightWheelCollider.motorTorque = carSpeed * motorForce * Time.fixedDeltaTime;
            ApplyBreaking();
        }

        private void ApplyBreaking()
        {
            frontRightWheelCollider.brakeTorque = currentbreakForce;
            frontLeftWheelCollider.brakeTorque = currentbreakForce;
            backLeftWheelCollider.brakeTorque = currentbreakForce;
            backRightWheelCollider.brakeTorque = currentbreakForce;
        }

        private void HandleSteering()
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
            frontLeftWheelCollider.steerAngle = currentSteerAngle;
            frontRightWheelCollider.steerAngle = currentSteerAngle;
        }

        private void UpdateWheels()
        {
            UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
            UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
            UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
            UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        }

        private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }

        public void ActivateForce() => rb.AddForce(transform.forward * 50f, ForceMode.VelocityChange);
    }
}