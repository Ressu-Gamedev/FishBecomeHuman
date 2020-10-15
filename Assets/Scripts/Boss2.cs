using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Boss2 : Boss
{
    public GameObject player;
    public GameObject enemy;
    public GameObject cam1;
    public GameObject cam2;
    public SpriteRenderer playerRender;
    public Sprite newSprite;
    public int lapCount = 7;
    public string task = " TO GO";
    public TextMeshProUGUI tasktext;
    public AudioSource audioS;
    public AudioClip newClip;
    public GameObject marioKart;
    public int lastDir = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            lapCount--;
            tasktext.text = (lapCount+1)/2 + task;
            tasktext.gameObject.SetActive(true);
            marioKart.transform.position += new Vector3(lastDir * 20f, lastDir * 7f, 0f);
            lastDir = -lastDir;
            if(lapCount <= 0){
                cam1.SetActive(false);
                cam2.SetActive(true);
                player.transform.position = newLoc;
                playerRender.sprite = newSprite;
                player.GetComponent<Animator>().SetInteger("State", 2);
                enemy.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                audioS.clip = newClip;
                audioS.Play();
            }
        }
    }
}
