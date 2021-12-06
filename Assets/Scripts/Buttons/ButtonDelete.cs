using UnityEngine;

public class ButtonDelete : MonoBehaviour
{
    private InputManager inputManager;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void OnMouseDown()
    {
        inputManager.DeleteNumber();
    }
}
