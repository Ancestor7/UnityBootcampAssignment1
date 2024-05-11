using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;
    public bool isWalking, isRunning, isJumping;
    public float walkSpeed = 1f, runSpeed = 1.5f, rotationSpeed=50f, jumpSpeed=10f; 
    private Vector3 moveDirection = Vector3.forward;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isWalking = animator.GetBool("isWalking");
        isRunning = animator.GetBool("isRunning");
        isJumping = animator.GetBool("isJumping");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        if (isWalking)
        {
            transform.position += Time.deltaTime * walkSpeed * transform.forward;
        }
        if(isRunning)
        {
            transform.position += runSpeed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            //transform.eulerAngles -= rotationSpeed * Time.deltaTime * new Vector3(0, 10, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); 
            //transform.eulerAngles += rotationSpeed * Time.deltaTime * new Vector3(0, 10, 0);
        }
    }
}
