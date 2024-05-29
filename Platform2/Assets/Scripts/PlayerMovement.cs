using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 velocity;
    public Animator animator;

    public GameObject DeathScreen;
    public GameObject FinishScreen;
    private bool isDead;

    private AudioSource audioSource;

    public AudioSource backgroundMusicSource;
    
    
    public TextMeshProUGUI playerScoreText;
    public Joystick joystick;
    
    public int score;
    
    private float speed = 5f;
    private float jump = 5f;
    private float horizontalMoveSpeed; 
    private bool grounded;
    

    private bool isGrounded = true;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Score: " + score.ToString();
        
        //joystick hareketi
        if (joystick.Horizontal > 0.2f)
        {
            horizontalMoveSpeed = 1;
        }
        else if (joystick.Horizontal < -0.2f)
        {
            horizontalMoveSpeed = -1;
        }
        else
        {
            horizontalMoveSpeed = 0;
        }
        
        
        //yatay da hareket etmesi için
        velocity = new Vector3(horizontalMoveSpeed, 0f);
        transform.position += velocity * speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        
        
        //joystick zıplama
        // if (joystick.Vertical > 0.5f && !animator.GetBool("isJumping"))
        // {
        //     rb2d.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        //     animator.SetBool("isJumping", true);
        //     //soundManagerSc.Jump();
        // }


        
        //ekrana dokunulduğunda zıplama
        // if (isGrounded)
        // {
        //     Jump();
        // }
        



        //karakterin bakış yönünü değiştirme (180 derece)
        if (horizontalMoveSpeed == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (horizontalMoveSpeed == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        
    
        
    }


    public void Jump()
    {
        if (isGrounded)
        {
            rb2d.velocity = Vector2.up * jump ;
            audioSource.Play();
        }
        

    }

    


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            animator.SetBool("isJumping", false);
            isGrounded = true;
        }
        
        if (col.gameObject.tag == "Flag")
        {
            if (backgroundMusicSource.isPlaying)
            {
                backgroundMusicSource.Stop();
            }
            FinishScreen.SetActive(true);
             
            
        }
        
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground" )
        {
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            isDead = true;
            Time.timeScale = 0;
            
            
            if (backgroundMusicSource.isPlaying)
            {
                backgroundMusicSource.Stop();
            }
            DeathScreen.SetActive(true);
             
            
            
        }
    }

    
    
    
}





