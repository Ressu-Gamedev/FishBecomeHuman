using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Boss1 : Boss
{
    public GameObject player;
    public GameObject enemy;
    public GameObject cam1;
    public GameObject cam2;
    public SpriteRenderer playerRender;
    public Sprite newSprite;
    public int clickCount = 100;
    public string task = " TO GO";
    public TextMeshProUGUI tasktext;
    public AudioSource audioS;
    public AudioClip newClip;

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            clickCount--;
            tasktext.text = clickCount + task;
            tasktext.gameObject.SetActive(true);
            if(clickCount <= 0){
                cam1.SetActive(false);
                cam2.SetActive(true);
                player.transform.position = newLoc;
                playerRender.sprite = newSprite;
                player.GetComponent<Animator>().SetInteger("State", 1);
                enemy.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                audioS.clip = newClip;
                audioS.Play();
            }
        }
    }
}
