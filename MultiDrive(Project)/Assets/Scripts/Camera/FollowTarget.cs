using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Space]
    [SerializeField] private float smoothSpeed = 0.125f;
    [Space]
    [SerializeField] private Vector3 locationOffset;
    [SerializeField] private Vector3 rotationOffset;

    private const float closerDistance = -4f;
    private const float farDistance = -6f;

    private void Start()
    {
        MoveCameraAway();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
    }
     
    public void MoveCameraCloser() => locationOffset = new Vector3(transform.localPosition.x, transform.localPosition.y, closerDistance); 
    
    public void MoveCameraAway() => locationOffset = new Vector3(transform.localPosition.x, transform.localPosition.y, farDistance);
}
