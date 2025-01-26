using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CubePeople
{
    public class EightDirectionMovement : MonoBehaviour
    {

        public float velocity = 5;
        public float turnSpeed = 10;

        Vector2 input;
        float angle;

        Quaternion targetRotation;
        public Transform cam; //Transform cam;

        FollowTarget ft;

        private bool isJumping = false;
        private float jumpStartY = 0;
        private float jumpCooldown = 1f;
        private float jumpTimer = 5f;
        private float jumpHeight = 2f;
        private float jumpSpeed = 3f;

        void Start()
        {
            //cam = Camera.main.transform;
            if (cam.GetComponent<FollowTarget>())
            {
                ft = cam.GetComponent<FollowTarget>();
            }
        }

        void Update()
        {
            GetInput();

            

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                Debug.Log("Trying to jump");
                StartJump();
            }
            if (isJumping)
            {
                PerformJump();
            }

            

            if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

            CalculateDirection();
            Rotate();
            Move();

            
        }
           
        void StartJump()
        {
            isJumping = true;
            //jumpStartY = transform.position.y;
            jumpTimer = 0f;
        }
        

        void PerformJump()
        {
            if(jumpTimer < jumpCooldown - 0.5f)
            {
                transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        void GetInput()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
        }

        void CalculateDirection()
        {
            angle = Mathf.Atan2(input.x, input.y);
            angle = Mathf.Rad2Deg * angle;
            angle += cam.eulerAngles.y;
        }

        void Rotate()
        {
            if (ft != null && ft.camRotation)
            {
                transform.rotation = Quaternion.Euler(0, input.x * 1.5f, 0) * transform.rotation;
            }
            else
            {
                targetRotation = Quaternion.Euler(0, angle, 0);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        void Move()
        {
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
    }
}
