using UnityEngine;

namespace Vehicle
{
    public class Car : Vehicle
    {
        private readonly Transform carTransform = null;
        private const float carSpeed = 5f;

        public Car(Transform transform) => this.carTransform = transform;

        public override void Move() => carTransform.Translate(Vector3.forward * carSpeed * Time.fixedDeltaTime);
    }
}