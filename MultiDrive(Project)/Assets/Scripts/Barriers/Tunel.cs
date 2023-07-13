using UnityEngine;

namespace Tunel
{
    public sealed class Tunel : MonoBehaviour
    {
        private const float speed = 10f;

        private void FixedUpdate() => Rotate();

        public void Rotate() => transform.Rotate(0f, speed * Time.fixedDeltaTime, 0f);
    }
}