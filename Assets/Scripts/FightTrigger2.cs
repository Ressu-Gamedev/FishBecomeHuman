using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FightTrigger2 : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;
    public CinemachineVirtualCamera camData; 
    public Transform followTarget;
    public Boss bossScript;
    public Vector2 newLoc;
    public Collider2D col;
    public Sprite newSprite;
    public SpriteRenderer sRender;
    public AudioSource audioS;
    public AudioClip newClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            camData.Follow = followTarget;
            cam1.SetActive(false);
            cam2.SetActive(true);
            bossScript.newLoc = collision.transform.position;
            collision.transform.position = newLoc;
            sRender.sprite = newSprite;
            audioS.clip = newClip;
            audioS.Play();
            Destroy(this);
        }
    }
}
