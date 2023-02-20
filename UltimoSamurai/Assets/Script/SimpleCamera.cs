using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public  Transform target;
    public  Vector3   offset; 
    private Vector3   velocity ;
    public  float     damping;


    void Update()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,movePosition,ref velocity, damping);
    }
}
