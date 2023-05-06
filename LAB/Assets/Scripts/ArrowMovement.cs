    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ArrowMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rigid;
        [SerializeField] int speed = 5;
        [SerializeField] GameObject balloon;
        [SerializeField] GameObject bird;
        [SerializeField] private Movement movementScript;
        [SerializeField] private Score scoreScript;
        
        // Start is called before the first frame update
        void Start()
        {        
            
            GameObject movementObject = GameObject.Find("mario");
            movementScript = movementObject.GetComponent<Movement>();

            GameObject scoreObject = GameObject.Find("Score_Keeper");
            scoreScript = scoreObject.GetComponent<Score>();

            if (rigid == null) {
                rigid = GetComponent<Rigidbody2D>();
            }
            if (balloon == null)
            {
                balloon = GameObject.FindGameObjectWithTag("Balloon");
            }
            if (bird == null)
            {
                bird = GameObject.FindGameObjectWithTag("Bird");
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //called potentially multiple times per frame
        //used for physics & movement
        void FixedUpdate()
        { 
            rigid.velocity = Vector2.up * speed; 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Balloon")
            {
                Destroy(gameObject);
                AudioManager.Instance.PlaySFX("Pop");
                Destroy(balloon);   

                float balloonSize = balloon.transform.localScale.z;
                float score = Score.DEFAULT_POINTS / balloonSize;
                score = Mathf.Round(score * 100f) / 100f;
                scoreScript.AddPoints(score);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else if (collision.gameObject.tag == "Bird") 
            {
                Destroy(gameObject); 
            }
            movementScript.isArrowSpawned = false;
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
            movementScript.isArrowSpawned = false;
        }
    }
