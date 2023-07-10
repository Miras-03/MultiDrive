using UnityEngine;

[CreateAssetMenu(fileName = "PlaneData", menuName = "DataContainer/VehicleData/PlaneData")]
public sealed class PlaneData : ScriptableObject
{
    [HideInInspector] public const float planeSpeed = 20f;
    [HideInInspector] public const float smoothSpeed = 1f;

    [HideInInspector] public const float yawAmount = 10f;
    [HideInInspector] public const float pitchAmount = 15f;
    [HideInInspector] public const float rollAmount = 110f;
}
