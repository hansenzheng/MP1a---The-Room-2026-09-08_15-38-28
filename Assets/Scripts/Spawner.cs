using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
     [SerializeField] private InputActionReference inputAction;

    private void OnEnable()
    {
        inputAction.action.Enable();
        inputAction.action.performed += SpawnObject;
    }

    private void OnDisable()
    {
        inputAction.action.performed -= SpawnObject;
    }

    private void SpawnObject(InputAction.CallbackContext ctx)
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        print("Object spawned");
    }
}
