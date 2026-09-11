using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private Light light;
    private bool isSwitched;
    [SerializeField] private InputActionReference inputAction;

    void Awake()
    {
        light.GetComponent<Light>();
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
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
            if (audioSource1) 
            {
                print("Light switched");
                audioSource1.Play();
            }

            if (!isSwitched)
            {
                light.color = Color.indianRed;
                audioSource2.Stop();
            } 
            else
            {
                light.color = Color.white;
                audioSource2.Play();
            }
            isSwitched = !isSwitched;
        }
    }
}
