using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = 5f;
    [SerializeField] private float verticalVelocity;
    public CharacterController controller;
    void Start()
    {
        
    }

    void Update()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        Vector3 moveXZ = (transform.forward * moveZ) + (transform.right * moveX);
        if(controller.isGrounded == true)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 fall = new Vector3(0, verticalVelocity, 0);
        Vector3 moveControll = (moveXZ + fall) * Time.deltaTime;
        controller.Move(moveControll);
    }
}
