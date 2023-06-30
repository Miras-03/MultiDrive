using UnityEngine;

[CreateAssetMenu(fileName = "VehicleData", menuName = "ScriptableObject/VehicleData")]
public class VehicleData : ScriptableObject
{
    public GameObject carPrefab;
    public GameObject planePrefab;
}
