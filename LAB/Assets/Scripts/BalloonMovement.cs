using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float growthRate = 0.1f;
    [SerializeField] float maxSize = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }
        speed = 15;

        InvokeRepeating("IncreaseSize", 5f, 3f);
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

    void IncreaseSize()
    {
        transform.localScale += new Vector3(growthRate, growthRate, growthRate);
        
        if (transform.localScale.x >= maxSize)
        {
            AudioManager.Instance.PlaySFX("Pop");
            Destroy(gameObject); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
