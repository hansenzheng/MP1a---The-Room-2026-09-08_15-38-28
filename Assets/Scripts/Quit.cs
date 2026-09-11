using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputAction.action.Enable();
        inputAction.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };
    }

}
