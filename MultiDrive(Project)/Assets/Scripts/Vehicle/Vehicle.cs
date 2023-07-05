using UnityEngine;

namespace Vehicle
{
    public abstract class Vehicle : MonoBehaviour
    {
        public abstract void Move();
        public abstract void Control();
    }
}
