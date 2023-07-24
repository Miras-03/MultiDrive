using UnityEngine;

namespace Tunel
{
    public sealed class BarrierRotate : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        [Space]
        [Header("Meshes of barrier")]
        [SerializeField] private Transform singleBarriers;
        [SerializeField] private Transform doubleBarriers;

        private void FixedUpdate()
        {
            LeftRotate();
            RightRotate();
        }

        public void LeftRotate() => doubleBarriers.Rotate(0f, speed * Time.fixedDeltaTime, 0f);
        public void RightRotate() => singleBarriers.Rotate(0f, -speed * Time.fixedDeltaTime, 0f);
    }
}