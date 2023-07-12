using UnityEngine;
using VehicleOption;

public sealed class CameraManager : MonoBehaviour
{
    [SerializeField] private VehicleManager vehicleManager;

    [Space]
    [SerializeField] private Vector3 locationOffset;
    [SerializeField] private Vector3 rotationOffset;

    private Transform target;

    private const float closerZDistance = -4f;
    private const float farZDistance = -6f;

    private const float closerYDistance = 2f;
    private const float farZYistance = 3f;

    private const float smoothSpeed = 0.125f;

    private void Start()
    {
        target = vehicleManager.currentPosition;
        MoveCameraAway();
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
}
