using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "DataContainer/VehicleData/CarData")]
public sealed class CarData : ScriptableObject
{
    [HideInInspector] public const float carSpeed = 5f;
    [HideInInspector] public const float motorForce = 1000f;
    [HideInInspector] public const float maxSteerAngle = 20f;
}
