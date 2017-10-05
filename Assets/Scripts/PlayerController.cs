using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator animator;
    private GameObject Player;

    public float speed = 2f;
    public float jumpSpeed = 1f;
    public float gravity = 1f;
    public bool isJumping;
    public bool checkJump;
    public Vector3 moveDirection = Vector3.zero;
    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    CharacterController controller;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        Player = instance.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        //  Attack();
        // Move();\
        Move_2();
    }

    void Move_2()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    private void Move()
    {
        if (!isAnimationRunning())
        {
            speed = Mathf.Clamp(speed, 0, 4);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetFloat("SpeedRunning", speed += 0.05f);
                Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                Player.transform.Translate(Vector3.right * speed * 4 * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetFloat("SpeedRunning", speed += 0.05f);
                Player.transform.rotation = new Quaternion(0, 180, 0, 0);
                Player.transform.Translate(Vector3.right * speed * 4 * Time.deltaTime);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {

            }
            else
            {
                speed = 0;
                animator.SetFloat("SpeedRunning", speed);
            }
        }
        else
        {
            speed = 0;
            animator.SetFloat("SpeedRunning", speed);
        }


    }
    private void Attack()
    {
        if (isAnimationRunning())
        {
            animator.ResetTrigger("param_Attack_0");
            animator.ResetTrigger("param_Attack_1");
            animator.ResetTrigger("param_Attack_2");
            animator.ResetTrigger("param_Kick_1");
            animator.ResetTrigger("param_Kick_2");
            animator.ResetTrigger("param_Jump");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("param_Attack_0");

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("param_Attack_1");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("param_Attack_2");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("param_Kick_1");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("param_Kick_2");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("param_Jump");
        }


    }
    bool isAnimationRunning()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_Normal") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_1") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_2") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Jumb"))
        {
            return true;
        }
        return false;
    }
}
