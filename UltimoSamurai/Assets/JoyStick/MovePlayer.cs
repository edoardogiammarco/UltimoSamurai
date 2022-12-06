    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MovePlayer : MonoBehaviour
    {
    
        public Joystick movementJoystick;
        public float playerSpeed;
        private Rigidbody2D rb;
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
                if( movementJoystick.joystickVec.x>0){
                gameObject.transform.localScale = new Vector2(1,1);
                rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
                }
                else {
                    gameObject.transform.localScale = new Vector2(-1,1);
                    rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
                    
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }