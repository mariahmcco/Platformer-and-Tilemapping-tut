using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCatController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    public Text scoreText;
    public Text winText;
    // Start is called before the first frame update
    private int score;
    public Text lifeText;
    private int life;

    public Text loseText;

    private GameObject myPlayer;
    public Vector2 pos;

    public AudioClip MusicClip;
    public AudioClip MusicClip2;
    public AudioSource MusicSource;

    Animator anim;

    private bool facingRight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        setScoreText ();
        winText.text = "";
        life = 3;
        setLifeText ();
        loseText.text = "";
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        MusicSource.clip = MusicClip;

        anim = GetComponent<Animator> ();

        facingRight =true;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        Flip(moveHorizontal);

       

        if (Input.GetKey("escape"))
        Application.Quit();

         //Idle -> running animation 
        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
        }

         if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp (KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }

        
    }
    private void Flip(float moveHorizontal)
    {
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive (false);
            score = score + 1;
            setScoreText ();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive (false);
            life = life - 1;
            setLifeText ();
        }
    }

    void setScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score == 4 )
        {
            transform.position = pos;
        }

        if (score >= 8)
        {
            winText.text = "You Win!";
            MusicSource.clip = MusicClip2;
            MusicSource.Play();
        }
    }

    void setLifeText ()
    {
        lifeText.text = "Lives: " + life.ToString ();
        if (life <= 0)
        {
            loseText.text = "You Lose.";
            Destroy(myPlayer);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground") 
        {
            anim.SetInteger("State", 0);

            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                anim.SetInteger("State", 2);
            }

                     //Idle -> running animation 
             if (Input.GetKey (KeyCode.LeftArrow))
                {
                 anim.SetInteger("State", 1);
                }


            if (Input.GetKey (KeyCode.RightArrow))
                {
                    anim.SetInteger("State", 1);
                }

           
        }
    }

}
