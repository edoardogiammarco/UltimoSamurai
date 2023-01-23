    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MovePlayer : MonoBehaviour
    {
    
        public Joystick movementJoystick;
        public float playerSpeed;
        private Rigidbody2D rb;
        public Animator animator;
        private int player_Scale = 2;
      //  private int playerscale;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
            if(movementJoystick.joystickVec.y != 0 || movementJoystick.joystickVec.x != 0)
            {
                if(movementJoystick.joystickVec.x>0)
                {
                    gameObject.transform.localScale = new Vector2(player_Scale,player_Scale);
                    animator.SetFloat("Speed",1);
                    rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed * Time.deltaTime, movementJoystick.joystickVec.y * playerSpeed * Time.deltaTime);
                }
                else
                {
                    gameObject.transform.localScale = new Vector2(-player_Scale,player_Scale);
                    animator.SetFloat("Speed",1);
                    rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed * Time.deltaTime, movementJoystick.joystickVec.y * playerSpeed * Time.deltaTime);
                }
            }
            else
            {
                animator.SetFloat("Speed",0);
                rb.velocity = Vector2.zero;
            }
        }
    }