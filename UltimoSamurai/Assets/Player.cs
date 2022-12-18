using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public int gold ; 

    // Start is called before the first frame update
    private void Start()
    {
        gold=0;
        boxCollider = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Reset MoveDelta
        moveDelta = Vector3.zero;
       // hit = Phisics2D.BoxCast(transform.position, boxCollider.size,0,new Vector2)
       // float x = Input.GetAxisRaw("Horizontal"); ma a che serve questa roba prima??
       Debug.Log(gold);
    }


}
