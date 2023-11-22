using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Animator animator;
    bool isWalking;
    bool walk = false;
    bool faceRight = false;
    bool faceLeft = false;
    bool faceForward = false;
    bool stopWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        QueryAnimations();
    }

    private void QueryAnimations()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            faceRight = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            faceLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            faceForward = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stopWalking = true;
        }

        if (faceRight)
        {
            transform.localScale = Vector3.one * 200;
            faceRight = false;
        }

        if (faceLeft)
        {
            transform.localScale = new Vector3(-200, 200, 200);
            faceLeft = false;
        }
    }

    private void FixedUpdate()
    {
        UpdateAnimations();
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (isWalking)
        {
            float moveAmount = Time.deltaTime * speed;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Do nothing, already going in the positive direction
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveAmount *= -1;
            }

            transform.localPosition += Vector3.right * moveAmount;
        }
    }

    void UpdateAnimations()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            walk = true;
        }

        if (walk && isWalking != true && !stopWalking)
        {
            animator.SetTrigger("StartWalking");
            isWalking = true;
        }
        else if (stopWalking)
        {
            animator.SetTrigger("StopWalking");
            isWalking = false;
            stopWalking = false;
            walk = false;
        }

        if (faceForward && isWalking != true)
        {
            animator.SetTrigger("FaceForward");
            faceForward = false;
        }
    }
}
