using UnityEngine;

namespace Tunel
{
    public sealed class BarrierRotate : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        [Space]
        [Header("Meshes of barrier")]
        [SerializeField] private Transform greenBarrier;
        [SerializeField] private Transform redBarrier;

        private void FixedUpdate()
        {
            LeftRotate();
            RightRotate();
        }

        public void LeftRotate() => redBarrier.Rotate(0f, speed * Time.fixedDeltaTime, 0f);
        public void RightRotate() => greenBarrier.Rotate(0f, -speed * Time.fixedDeltaTime, 0f);
    }
}