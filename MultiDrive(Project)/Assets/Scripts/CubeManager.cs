using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Transform cubeTransform;
    private Cube cube;

    void Start()
    {
        cube = cubeTransform.GetComponent<Cube>();
    }

    void FixedUpdate()
    {
        cube.Move();
    }
}
