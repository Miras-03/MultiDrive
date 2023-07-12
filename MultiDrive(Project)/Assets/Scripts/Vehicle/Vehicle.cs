using UnityEngine;

namespace VehicleOption
{
    public abstract class Vehicle : MonoBehaviour
    {
        public abstract void Move();
        public abstract void Control();
    }
}
