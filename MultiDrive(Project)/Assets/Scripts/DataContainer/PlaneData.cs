using UnityEngine;

[CreateAssetMenu(fileName = "PlaneData", menuName = "DataContainer/VehicleData/PlaneData")]
public sealed class PlaneData : ScriptableObject
{
    [HideInInspector] public const float smoothSpeed = 0.9f;

    [HideInInspector] public const float yawAmount = 12f;
    [HideInInspector] public const float pitchAmount = 20f;
    [HideInInspector] public const float rollAmount = 120f;
}
