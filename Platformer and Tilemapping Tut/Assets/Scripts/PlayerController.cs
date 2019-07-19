using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        
        if (Input.GetKey("escape"))
        Application.Quit();
        
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
            if(Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

}
