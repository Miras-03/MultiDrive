using System.Collections;
using UnityEngine;
using VehicleOption;

public class SetVehicleFlag : MonoBehaviour
{
    [SerializeField] private Car car;
    private bool isPlane;

    private void Start() => isPlane = car.isPlane;

    private void OnTriggerEnter()
    {
        isPlane = car.isPlane;
        car.isPlane = !isPlane;
        StartCoroutine(car.OffGroundTimer());
    }
}
