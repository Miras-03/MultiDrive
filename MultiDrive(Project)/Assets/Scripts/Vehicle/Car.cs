using UnityEngine;
using System.Collections;
using Health;

namespace VehicleOption
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : Vehicle, IEnhancable, ISoundable
    {
        [SerializeField] private HealthController healthController;

        [Space(15)]
        [Header("CarProperties")]
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private Transform centerOfGravity;
        [SerializeField] private BoxCollider carCollider;

        [Space(10)]
        [Header("TireSmokes")]
        [SerializeField] private ParticleSystem leftTireSmoke;
        [SerializeField] private ParticleSystem rightTireSmoke;

        [Space(10)]
        [Header("Sounds")]
        [SerializeField] private AudioSource damageSound;
        [SerializeField] private AudioSource skidSound;

        [Space(5)]
        [SerializeField] private LayerMask groundLayerMask;

        private Vector3 moveForce;
        private Rigidbody rb;

        [Space(10)]
        [Header("CarSettings")]
        public float moveSpeed = 15f;
        public float maxSpeed = 15f;

        private const float drag = CarData.drag;
        public float steerAngle = CarData.steerAngle;
        private const float forceNewton = CarData.forceNewton;
        private const float smoothSpeed = CarData.smoothSpeed;

        private const int damageValue = 5;
        private float steerInput;
        private bool isFinished = false;

        public bool IsFinished { set => isFinished = value; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfGravity.localPosition;
        }

        private void OnEnable() => ResetProperties();

        public void ActivateForce() => rb.AddForce(transform.forward * forceNewton, ForceMode.VelocityChange);

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

            if (IsSkidding() && !skidSound.isPlaying && !isFinished)
            {
                PlaySkidSound();    
                PlaySmoke();
            }
            else if (IsntSkidding() || isFinished)
            {
                StopSkidSound();
                StopSmoke();
            }

            Drag();
        }

        public override void Control()
        {
            steerInput = floatingJoystick.Horizontal * smoothSpeed;
            transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.fixedDeltaTime);
        }

        private bool IsTouchingGround()
        {
            Vector3 halfExtents = carCollider.bounds.extents;
            halfExtents.y += 0.1f;
            Vector3 center = carCollider.bounds.center;
            center.y -= halfExtents.y;

            bool isTouchingGround = Physics.OverlapBox(center, halfExtents, Quaternion.identity, groundLayerMask).Length > 0;
            return isTouchingGround;
        }

        private bool IsSkidding() => Mathf.Abs(steerInput) > 0.05f && IsTouchingGround();
        private bool IsntSkidding() => Mathf.Abs(steerInput) <= 0.05f || !IsTouchingGround();

        private void PlaySkidSound() => skidSound.Play();
        private void StopSkidSound() => skidSound.Stop();

        private void PlaySmoke()
        {
            leftTireSmoke.Play();
            rightTireSmoke.Play();
        }
        private void StopSmoke()
        {
            leftTireSmoke.Stop();
            rightTireSmoke.Stop();
        }

        private void Drag()
        {
            moveForce *= drag;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Barrier"))
            {
                Sound(damageSound);
                healthController.TakeDamage(damageValue);
            }
        }

        public void Sound(AudioSource sound) => sound.Play();
    }
}