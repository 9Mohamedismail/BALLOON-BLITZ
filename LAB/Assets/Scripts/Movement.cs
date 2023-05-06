using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] public bool isArrowSpawned = false;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject Arrow;
    [SerializeField] int speed = 15;
    [SerializeField] bool isFacingRight = true;
    private Vector2 screenSize;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1") && !isArrowSpawned) { // Only spawn arrow if one hasn't already been spawned
            Instantiate(Arrow, rigid.transform.position, Quaternion.identity);
            isArrowSpawned = true;
        }
    }
    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();

        if (transform.position.x >= 14 && isFacingRight) { 
           // prevent player from going left
        } else if (transform.position.x <= -14 && !isFacingRight) {
            // prevent player from going right
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    } 
    
}
