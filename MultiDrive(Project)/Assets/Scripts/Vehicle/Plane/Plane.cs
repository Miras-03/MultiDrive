using UnityEngine;
using Health;

namespace VehicleOption
{
    public class Plane : Vehicle, IDieableObserver, ISoundable
    {
        [SerializeField] private Car car;

        [Space(20)]
        [Header("Plane properties")]
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private AudioSource damage;
        [SerializeField] private Transform tunelZone;

        private Rigidbody rb;

        private float horizontalInput;
        private float verticalInput;

        private float yaw;
        private float pitch;
        private float roll;

        [Space(20)]
        [Header("PlaneSettings")]
        [SerializeField] private float planeSpeed = 20f;
        private float smoothSpeed = PlaneData.smoothSpeed;

        private const float yawAmount = PlaneData.yawAmount;
        private const float rollAmount = PlaneData.rollAmount;

        private float currentYawVelocity;
        private float currentPitchVelocity;
        private float currentRollVelocity;

        private void Awake() => rb = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            ResetProperties();
            car.isPlane = true;
        }
        private void OnDisable() => car.isPlane = false;

        private void ResetProperties()
        {
            transform.position = new Vector3(tunelZone.position.x, tunelZone.position.y, transform.position.z);

            yaw = 0f;
            currentYawVelocity = 0f;
            currentPitchVelocity = 0f;
            currentRollVelocity = 0f;
        }

        public override void Move()
        {
            Vector3 movement = transform.forward * planeSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }

        public override void Control()
        {
            InputOfJoystick();
            ControlSetting();
        }

        private void InputOfJoystick()
        {
            horizontalInput = floatingJoystick.Horizontal;
            verticalInput = floatingJoystick.Vertical;
        }

        private void ControlSetting()
        {
            yaw = Mathf.SmoothDamp(yaw, horizontalInput * yawAmount, ref currentYawVelocity, smoothSpeed);
            pitch = Mathf.SmoothDamp(pitch, verticalInput * planeSpeed, ref currentPitchVelocity, smoothSpeed);
            roll = Mathf.SmoothDamp(roll, -horizontalInput * rollAmount, ref currentRollVelocity, smoothSpeed);

            transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
        }

        public void OnHealthOver() => Destroy(this);

        public void Sound(AudioSource sound) => sound.Play();
    }
}
