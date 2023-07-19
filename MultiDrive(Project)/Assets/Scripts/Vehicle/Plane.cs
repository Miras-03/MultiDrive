using UnityEngine;
using Health;

namespace VehicleOption
{
    public class Plane : Vehicle, IDieableObserver, ISoundable
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private AudioSource damage;

        private Rigidbody rb;

        private float horizontalInput;
        private float verticalInput;

        private float yaw;
        private float pitch;
        private float roll;

        private const float planeSpeed = PlaneData.planeSpeed;
        private float smoothSpeed = PlaneData.smoothSpeed;

        private const float yawAmount = PlaneData.yawAmount;
        private const float pitchAmount = PlaneData.pitchAmount;
        private const float rollAmount = PlaneData.rollAmount;

        private float currentYawVelocity;
        private float currentPitchVelocity;
        private float currentRollVelocity;

        private const int damageValue = 5;

        private void Awake() => rb = GetComponent<Rigidbody>();

        private void OnEnable()
        {
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
            pitch = Mathf.SmoothDamp(pitch, verticalInput * pitchAmount, ref currentPitchVelocity, smoothSpeed);
            roll = Mathf.SmoothDamp(roll, -horizontalInput * rollAmount, ref currentRollVelocity, smoothSpeed);

            transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
        }

        private void OnCollisionEnter()
        {
            Sound(damage);
            healthController.TakeDamage(damageValue);
        }

        public void OnHealthOver() => Destroy(this);

        public void Sound(AudioSource sound) => sound.Play();
    }
}
