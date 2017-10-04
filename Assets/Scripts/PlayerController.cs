using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private GameObject Player;
    // Use this for initialization
    private void Start()
    {

        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");


    }

    // Update is called once per frame
    private void Update()
    {
        Attack();
        Move();

    }
    private float speed = 0;
    private void Move()
    {
        
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_1") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_2") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Jumb"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetFloat("Vel_x", speed += 0.05f);

                Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                Player.transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetFloat("Vel_x", speed += 0.05f); 

                Player.transform.rotation = new Quaternion(0, 180, 0, 0);
                Player.transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }
            else
            {
                speed = 0;
                animator.SetFloat("Vel_x", speed);
               
            }
        }


    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("param_Attack_0", true);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("param_Attack_1", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("param_Attack_2", true);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("param_Kick_1", true);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("param_Kick_2", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("param_Jump", true);
        }
        else
        {

            animator.SetBool("param_Attack_0", false);
            animator.SetBool("param_Attack_1", false);
            animator.SetBool("param_Attack_2", false);
            animator.SetBool("param_Jump", false);
            animator.SetBool("param_Kick_1", false);
            animator.SetBool("param_Kick_2", false);
        }

    }

}
