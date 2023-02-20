using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float strength=16 , delay = 0.15f;
    public UnityEvent OnBegin, OnDone;
     
                        /* Knockback implementation */
                        
    /* 
        This method takes a sender GameObject as a parameter
        and applies a knockback force to the game object that the script is attached to,
        based on the direction from the sender to the game object
        It also starts a coroutine to reset the Rigidbody2D's velocity after a delay
    */
    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction*strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
