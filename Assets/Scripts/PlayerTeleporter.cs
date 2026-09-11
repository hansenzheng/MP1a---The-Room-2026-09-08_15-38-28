using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private Transform inRoomLocation;
    [SerializeField] private Transform outsideLocation;
    private bool isSwitched;
    private AudioSource audioSource;
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
                xrOrigin.transform.position = inRoomLocation.position;
            }
            else
            {
                xrOrigin.transform.position = outsideLocation.position;
            }
            isSwitched = !isSwitched;
        }
    }
    
}
