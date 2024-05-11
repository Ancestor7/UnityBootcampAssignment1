using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private float jumpTimer = 0f;
    private bool isJumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (!isJumping && (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)))
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            jumpTimer = 5f/3f;
            //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);
            //Debug.Log("Keydown");
        }
        if (isJumping)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                animator.SetBool("isJumping", false);
                isJumping = false;
            }
            //Debug.Log("isjump");
        }
    }
}
