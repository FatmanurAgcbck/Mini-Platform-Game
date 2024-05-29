using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    //[SerializeField] private AudioClip coinSound;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    
    

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            
            
            PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
            player.score += 5;
            gameObject.SetActive(false);
            
            
        }
    }

    
}
