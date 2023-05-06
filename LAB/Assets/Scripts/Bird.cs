using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(speed, rigid.velocity.y);
        
        if (transform.position.x >= 11 && isFacingRight) { 
           Flip();
           speed = -15;
        } else if (transform.position.x <= -11 && !isFacingRight) {
            Flip();
            speed = 15;
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
