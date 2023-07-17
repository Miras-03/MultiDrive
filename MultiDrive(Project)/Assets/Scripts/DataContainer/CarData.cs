using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "DataContainer/VehicleData/CarData")]
public sealed class CarData : ScriptableObject
{
    public const float carSpeed = 15f;
    public const float maxSpeed = 15f;
    public const float drag = 0.98f;
    public const float steerAngle = 20f;
    public const float forceNewton = 100f;
    public const float smoothSpeed = 0.17f;
}
