using UnityEngine;
using Health;

namespace VehicleOption
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : Vehicle, IEnhancable, ISoundable
    {
        [SerializeField] private HealthController healthController;

        [Space]
        [Header("CarProperties")]
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private Transform centerOfGravity;
        [SerializeField] private BoxCollider carCollider;

        [Space]
        [Header("Sounds")]
        [SerializeField] private AudioSource skidAudio;
        [SerializeField] private AudioSource damageSound;
        [SerializeField] private AudioSource accelerate;

        [Space]
        [SerializeField] private LayerMask groundLayerMask;

        private Vector3 moveForce;
        private Rigidbody rb;

        [HideInInspector] public float moveSpeed = CarData.carSpeed;
        private const float maxSpeed = CarData.maxSpeed;
        private const float drag = CarData.drag;
        private const float steerAngle = CarData.steerAngle;
        private const float forceNewton = CarData.forceNewton;
        private const float smoothSpeed = CarData.smoothSpeed;

        private const int damageValue = 5;

        private float steerInput;

        private void Awake() => rb = GetComponent<Rigidbody>();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfGravity.localPosition;
        }

        private void OnEnable() => ResetProperties();

        public void ActivateForce()
        {
            Sound(accelerate);
            rb.AddForce(transform.forward * forceNewton, ForceMode.Impulse);
        }

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

            if (Mathf.Abs(floatingJoystick.Horizontal) > 0 && IsTouchingGround() && !skidAudio.isPlaying)
                skidAudio.Play();
            else if (Mathf.Abs(floatingJoystick.Horizontal) <= 0f || !IsTouchingGround() && skidAudio.isPlaying)
                skidAudio.Stop();
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