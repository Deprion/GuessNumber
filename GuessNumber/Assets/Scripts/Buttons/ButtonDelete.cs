using UnityEngine;

public class ButtonDelete : MonoBehaviour
{
    private InputManager inputManager;
    private float delay = 0.8f;
    float time = 0f;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void OnMouseDown()
    {
        inputManager.DeleteNumber();
    }
    private void OnMouseDrag()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            inputManager.DeleteNumberWhole();
            time = 0f;
        }
    }
    private void OnMouseUp()
    {
        time = 0;
    }
}
