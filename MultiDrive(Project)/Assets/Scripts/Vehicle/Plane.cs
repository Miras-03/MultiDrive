using UnityEngine;

namespace Vehicle
{
    public class Plane : Vehicle
    {
        private readonly Transform planeTransform = null;
        private const float planeSpeed = 10f;

        public Plane(Transform transform) => planeTransform = transform;

        public override void Move() => planeTransform.Translate(Vector3.forward * planeSpeed * Time.fixedDeltaTime);

    }
}