
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class PlanetSystem : MonoBehaviour
{
    [SerializeField] private GameObject planetSystem;
    [SerializeField] private float rotationSpeed = 90;

    private void Update()
    {
        planetSystem.transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
