using UnityEngine;
using System.Collections;

namespace VehicleOption
{
    [RequireComponent(typeof(Rigidbody))]
    public class Car : Vehicle
    {
        [SerializeField] private RestartGame restartGame;

        [Space(20)]
        [Header("CarProperties")]
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private Transform centerOfGravity;
        [SerializeField] private BoxCollider carCollider;

        [Space(20)]
        [Header("CarSettings")]
        [HideInInspector] public float moveSpeed = CarData.moveSpeed;
        public float maxSpeed = CarData.maxSpeed;
        private const float drag = CarData.drag;
        public float steerAngle = CarData.steerAngle;
        private const float driftAmount = 0.03f;
        private const float smoothSpeed = CarData.smoothSpeed;

        [Space(20)]
        [Header("TireSmokes")]
        [SerializeField] private ParticleSystem leftTireSmoke;
        [SerializeField] private ParticleSystem rightTireSmoke;

        [Space(20)]
        [Header("Sounds")]
        [SerializeField] private AudioSource skidSound;

        [Space(10)]
        [SerializeField] private LayerMask groundLayerMask;

        [Space(10)]
        [Header("DriftSettings")]
        private const float maxTurnSpeed = 10f;
        private const float accelerationRate = 5f;
        [SerializeField] private float decelerationRate = 0.5f;
        [SerializeField] private AnimationCurve decelerationCurve;

        private Vector3 moveForce;
        private Rigidbody rb;

        private float offGroundTime;
        private bool isTimerActive;
        [HideInInspector] public bool isPlane = false;

        private float steerInput;
        private bool isFinished = false;

        public bool IsFinished { set => isFinished = value; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfGravity.localPosition;
        }

        private void OnEnable() => ResetProperties();

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

            if (IsTouchingGround())
            {
                offGroundTime = 0f;
                isTimerActive = false;
            }
            else if (!isTimerActive)
                StartCoroutine(OffGroundTimer());

            Drag();
        }

        public override void Control()
        {
            steerInput = floatingJoystick.Horizontal * smoothSpeed;
            float turnSpeed = maxTurnSpeed * Mathf.Abs(steerInput);

            float speedPercentage = moveSpeed / maxSpeed;

            float decelerationFactor = decelerationCurve.Evaluate(speedPercentage);

            if (IsSkidding() && !isFinished)
                moveSpeed = Mathf.MoveTowards(moveSpeed, turnSpeed, Time.fixedDeltaTime * decelerationRate * decelerationFactor);
            else
                moveSpeed = Mathf.MoveTowards(moveSpeed, maxSpeed, Time.fixedDeltaTime * accelerationRate);

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

        private IEnumerator OffGroundTimer()
        {
            isTimerActive = true;

            const int timerWaitSeconds = 2;
            const int waitForSeconds = 1;
            const float perSeconds = 1f;

            while (offGroundTime < timerWaitSeconds && !isPlane)
            {
                yield return new WaitForSeconds(waitForSeconds);
                offGroundTime += perSeconds;
            }

            if (!isPlane)
                restartGame.OnHealthOver();
        }


        private bool IsSkidding() => Mathf.Abs(steerInput) > driftAmount && IsTouchingGround();
        private bool IsntSkidding() => Mathf.Abs(steerInput) <= driftAmount || !IsTouchingGround();

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
    }
}