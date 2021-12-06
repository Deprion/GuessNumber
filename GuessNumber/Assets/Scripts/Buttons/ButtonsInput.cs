using UnityEngine;

public class ButtonsInput : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField]
    private int num;
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void OnMouseDown()
    {
        inputManager.AddNumber(num);
    }
}
