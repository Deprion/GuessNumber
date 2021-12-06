using UnityEngine;

public class ButtonAccept : MonoBehaviour
{
    private InputManager inputManager;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void OnMouseDown()
    {
        inputManager.AcceptNumber();
    }
}
