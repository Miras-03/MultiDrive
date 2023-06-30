using UnityEngine;

namespace DesignPatterns.Strategy
{
    public class PlaneStrategy : MonoBehaviour, IVehicleStrategy
    {
        void IVehicleStrategy.Move() => Debug.Log("Flying by plane");
    }
}
