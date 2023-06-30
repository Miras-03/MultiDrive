using UnityEngine;

namespace DesignPatterns.Strategy
{
    public class CarStrategy : MonoBehaviour, IVehicleStrategy
    {
        void IVehicleStrategy.Move() => Debug.Log("Driving by car");
    }
}
