using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;

namespace ClearSky
{
    public class Control : WizJohny
    {
        
    void Start()
        {
            Restart();
            rb = GetComponent<Rigidbody2D>();
        }
        
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private void Update()
        {
            Restart();
            if (alive)
            {
                // Hurt();
                // Die();
                // Attack();
                Jump();
                Run();
                // Idle();

            }
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //
        // }
        
        void Restart()
        {
            // if (Input.GetKeyDown(KeyCode.Alpha0))
            // {
                // anim.SetTrigger("isIdle");
                IdleJohny();
                alive = true;
            // }
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            // Debug.Log(anim);
   
    
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction, 1, 1);
                // ResetAnimation();
                // anim.SetTrigger("isRun");
                RunJohny();
            }
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction, 1, 1);
                // ResetAnimation();
                // anim.SetTrigger("isRun");
                RunJohny();
            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
      
            {
                isJumping = true;
                // ResetAnimation();
                JumpJohny();
                // anim.SetTrigger("isJump");

            }
            if (!isJumping)
            {
                // anim.SetTrigger("isIdle");
                // ResetAnimation();
                // IdleJohny();
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        
    }
}
