using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource lightSwitchAudioSource;
    [SerializeField] private AudioSource airVentAudioSource;
    [SerializeField] private Light light;
    private bool isSwitched = true;
    [SerializeField] private InputActionReference inputAction;

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
            if (lightSwitchAudioSource) 
            {
                print("Light switched");
                lightSwitchAudioSource.Play();
            }

            // Light is on, turn it off and stop the air vent audio source
            if (isSwitched)
            {
                print("air vent off");
                light.color = Color.indianRed;
                airVentAudioSource.Stop();
            } 
            // Light is off, turn it on and play the air vent audio source
            else
            {
                print("air vent on");
                light.color = Color.white;
                airVentAudioSource.Play();
            }
            isSwitched = !isSwitched;
        }
    }
}
