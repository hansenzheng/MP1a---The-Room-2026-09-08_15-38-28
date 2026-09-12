using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject xrOrigin;
    [SerializeField] private Transform inRoomLocation;
    [SerializeField] private Transform outsideLocation;
    private bool isSwitched;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private InputActionReference inputAction;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        xrOrigin.transform.position = inRoomLocation.position;
    }

    private void OnEnable()
    {
        inputAction.action.Enable();
        inputAction.action.performed += swapPosition;
    }

    private void OnDisable()
    {
        inputAction.action.performed -= swapPosition;
    }

    private void swapPosition(InputAction.CallbackContext ctx)
    {
        if (xrOrigin)
        {
            audioSource.Play();
            if (isSwitched)
            {
                print("Switching to in room location");
                xrOrigin.transform.position = inRoomLocation.position;
                xrOrigin.transform.rotation = inRoomLocation.rotation;
            }
            else
            {
                print("Switching to outside location");
                xrOrigin.transform.position = outsideLocation.position;
                xrOrigin.transform.rotation = outsideLocation.rotation;
            }
            isSwitched = !isSwitched;
        }
    }
    
}
