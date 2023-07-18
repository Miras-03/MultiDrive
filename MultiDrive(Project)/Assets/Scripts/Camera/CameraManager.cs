using UnityEngine;
using VehicleOption;
using Health;

namespace CameraOption
{
    public sealed class CameraManager : MonoBehaviour, IDieableObserver
    {
        [SerializeField] private VehicleManager vehicleManager;

        [Space]
        private Vector3 locationOffset;
        private Vector3 rotationOffset;

        private Transform target;

        private const float farZYistance = 3f;
        private const float farZDistance = -7f;

        private const float closerYDistance = 3f;
        private const float closerZDistance = -5f;

        private const float rotationXValue = 12f;

        private const float smoothSpeed = 0.125f;

        private void Start()
        {
            target = vehicleManager.currentPosition;
            rotationOffset.x = rotationXValue;
            MoveCameraCloser();
        }

        private void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
            Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
            transform.rotation = smoothedrotation;
        }

        public void MoveCameraCloser()
        {
            locationOffset.z = closerZDistance;
            locationOffset.y = closerYDistance;
        }

        public void MoveCameraAway()
        {
            locationOffset.z = farZDistance;
            locationOffset.y = farZYistance;
        }

        public void OnHealthOver() => Destroy(this);
    }
}