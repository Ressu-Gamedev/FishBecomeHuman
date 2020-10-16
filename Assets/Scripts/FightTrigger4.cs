using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FightTrigger4 : MonoBehaviour
{
    public PlayerMovement playerScript;
    public Vector2 newLoc;
    public Collider2D col;
    public AudioSource audioS;
    public AudioClip newClip;
    public AudioClip speech;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.position = newLoc;
            playerScript.scaleX *= 0.3f;
            playerScript.scaleY *= 0.3f;
            playerScript.speed *= 0.3f;
            collision.transform.localScale = new Vector2(playerScript.scaleX, playerScript.scaleY);
            //audioS.clip = newClip;
            //audioS.Play();
            audioS.PlayOneShot(speech, 1f);
            Destroy(this);
        }
    }
}
