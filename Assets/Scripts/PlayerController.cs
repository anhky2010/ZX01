using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator animator;
    private GameObject Player;
    private Rigidbody2D rigidbody2D;
    public float speed = 2f;
    public float jumpSpeed = 5f;
    public bool isJumping;
    public bool checkJump;
    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        Player = instance.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        Attack();
        Move();
    }


    private void Move()
    {
        float speedAxis = 0;
        if (!isAnimationRunning())
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                speedAxis = Input.GetAxis("Horizontal");

                animator.SetFloat("SpeedRunning", speedAxis);

                Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                Player.transform.Translate(Vector3.right * speedAxis * speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                speedAxis = Input.GetAxis("Horizontal") * -1;

                animator.SetFloat("SpeedRunning", speedAxis);


                Player.transform.rotation = new Quaternion(0, 180, 0, 0);
                Player.transform.Translate(Vector3.right * speedAxis * speed * Time.deltaTime);
            }
            else
            {
                animator.SetFloat("SpeedRunning", speedAxis);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                isJumping = true;
                // float temp = transform.position.y + 10;
                //  transform.position = new Vector3(transform.position.x, temp, transform.position.z);
                rigidbody2D.AddForce(Vector2.up * jumpSpeed);
            }
        }
        else
        {
            animator.SetFloat("SpeedRunning", speedAxis);
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
            //  animator.ResetTrigger("param_Jump");
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
            animator.SetBool("param_Jump", isJumping);
        }


    }
    bool isAnimationRunning()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_Normal") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_1") ||
           animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_2"))
        {
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            isJumping = false;
        animator.SetBool("param_Jump", isJumping);

    }
}
