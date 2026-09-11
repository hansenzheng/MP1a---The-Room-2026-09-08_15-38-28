using Unity.Mathematics;
using UnityEngine;

public class Comet : MonoBehaviour
{
    // The center of mass of the planetary system that the comet moves around
    [SerializeField] private Transform barycenter;
    [SerializeField] private Transform cometTransform;
    // Tracks velocity of the comet. Starts with an inital velocity of 1 in the z direction
    [SerializeField] private Vector3 cometVelocity = new(0, 0, 1);
    [SerializeField] private float gravity = 0.2f;

    private void Update()
    {
        Vector3 relativePosition = cometTransform.position - barycenter.position;

        float distance = math.sqrt(
            math.pow(relativePosition.x, 2) + 
            math.pow(relativePosition.y, 2) + 
            math.pow(relativePosition.z, 2));

        float ax = - gravity * relativePosition.x / math.pow(distance, 3);
        float ay = - gravity * relativePosition.y / math.pow(distance, 3);
        float az = - gravity * relativePosition.z / math.pow(distance, 3);
        
        cometVelocity.x += ax * Time.deltaTime; 
        cometVelocity.y += ay * Time.deltaTime;
        cometVelocity.z += az * Time.deltaTime;

        cometTransform.position += cometVelocity * Time.deltaTime;
    }
}
