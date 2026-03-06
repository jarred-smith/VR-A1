using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CharacterController characterController;
    public float movementSpeed = 10f, rotationSpeed = 5f, JumpForce = 10f, Gravity = -30f;
    private float rotationY;
    private float verticalVelocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        characterController.Move(move);

        verticalVelocity = verticalVelocity + Gravity*Time.deltaTime;
        characterController.Move(new Vector3(0, verticalVelocity, 0)*Time.deltaTime);
    }
    public void Rotate(Vector2 rotationVector)
    {
        rotationY += rotationVector.x * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotationY, 0);
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = JumpForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
