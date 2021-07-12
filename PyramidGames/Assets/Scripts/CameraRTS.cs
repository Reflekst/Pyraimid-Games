using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRTS : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;
    [SerializeField] 
    private int rotationSpeed;


    private InputMaster inputs;
    private void Awake()
    {
        inputs = new InputMaster();
    }
    private void OnEnable()
    {
        inputs.Enable();    
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    private void FixedUpdate()
    {
        MoveCamera();

        RotateCamera();
    }

    private void MoveCamera()
    {
        Vector2 inputVector = inputs.Camera.Move.ReadValue<Vector2>();

        transform.Translate(new Vector3(inputVector.x * moveSpeed * Time.deltaTime, 0, inputVector.y * moveSpeed * Time.deltaTime));
    }

    private void RotateCamera()
    {
        float inputRotate = inputs.Camera.Rotate.ReadValue<float>();

        transform.RotateAround(transform.position, Vector3.up, inputRotate * rotationSpeed * Time.deltaTime);
    }
}

