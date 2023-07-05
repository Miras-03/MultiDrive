using UnityEngine;

[CreateAssetMenu(fileName = "VehicleData", menuName = "DataContainer/VehicleData")]
public class DataContainer : ScriptableObject
{
    public float speed;
    public GameObject vehicleTransform;
}
