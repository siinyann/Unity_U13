using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    InputAction lookAction;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
    }
    void Update()
    {
        //mouse control
        Vector2 lookValue = lookAction.ReadValue<Vector2>();
        Vector2 clampedLookValue = new Vector2(lookValue.x, Mathf.Clamp(lookValue.y, -90f, 90f));
        transform.RotateAround(gameObject.transform.position, -transform.right, clampedLookValue.y);

        if (Cursor.lockState == CursorLockMode.None && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
        }        
    }

}
