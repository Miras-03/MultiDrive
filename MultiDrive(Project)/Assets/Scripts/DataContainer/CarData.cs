using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "DataContainer/VehicleData/CarData")]
public sealed class CarData : ScriptableObject
{
    public const float moveSpeed = 0f;
    public const float maxSpeed = 60f;
    public const float drag = 0.98f;
    public const float steerAngle = 20f;
    public const float forceNewton = 100f;
    public const float smoothSpeed = 0.17f;
}
