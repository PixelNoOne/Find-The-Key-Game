using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float gravity = 15f;
    [SerializeField] private float verticalVelocity;
    public event Action iWalking;
    public event Action iStay;
    public CharacterController controller;
    public RewardUi reward;
    Animator animator;
    public bool iCantWork = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        iCantWork = reward.rewardWindowOpen;
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        if (!iCantWork)
        {
            Vector3 moveXZ = (transform.forward * moveZ) + (transform.right * moveX);
            moveXZ.x = moveXZ.x * speed;
            moveXZ.z = moveXZ.z * speed;
            if (controller.isGrounded == true)
            {
                verticalVelocity = -2f;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            Vector3 fall = new Vector3(0, verticalVelocity, 0);
            Vector3 moveControll = (moveXZ + fall) * Time.deltaTime;
            controller.Move(moveControll);
            bool iWalk = moveXZ.magnitude > 0.1f;
            animator.SetBool("iWalk", iWalk);
            if(animator.GetBool("iWalk") == true)
            {
                iWalking?.Invoke();
            }
            else
            {
                iStay?.Invoke();
            }
        }
    }
}
