using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    InputAction moveAction;
    InputAction lookAction;
    // Start is called before the first frame update
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }
    // Update is called once per frame
    void Update()
    {
        //movement
        Vector2 lookValue = lookAction.ReadValue<Vector2>();
        transform.RotateAround(gameObject.transform.position, Vector3.up, lookValue.x);
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue.y * Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Translate(moveValue.x * Vector3.right * Time.deltaTime * moveSpeed);
        if (transform.localPosition.y < -40)
        {
            transform.position = new Vector3(0, 1, -2.5f);
        }
    }
}