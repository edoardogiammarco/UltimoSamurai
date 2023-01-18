using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Reset MoveDelta
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
    }


    
}
