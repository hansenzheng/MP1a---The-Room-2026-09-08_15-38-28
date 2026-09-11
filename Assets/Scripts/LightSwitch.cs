using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Light light;
    private bool isSwitched;
    [SerializeField] private InputActionReference inputAction;

    void Awake()
    {
        light.GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        inputAction.action.Enable();
        inputAction.action.performed += ChangeLightColor;
    }

    private void OnDisable()
    {
        inputAction.action.performed -= ChangeLightColor;
    }

    private void ChangeLightColor(InputAction.CallbackContext ctx)
    {
        if (light)
        {
            if (audioSource) 
            {
                print("Light switched");
                audioSource.Play();
            }

            if (!isSwitched)
            {
                light.color = Color.indianRed;
            } 
            else
            {
                light.color = Color.white;
            }
            isSwitched = !isSwitched;
        }
    }
}
