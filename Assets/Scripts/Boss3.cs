using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Boss3 : Boss
{
    public GameObject player;
    public GameObject enemy;
    public GameObject cam1;
    public GameObject cam2;
    public SpriteRenderer playerRender;
    public Sprite newSprite;
    public string task = " TO GO";
    public TextMeshProUGUI tasktext;
    public AudioSource audioS;
    public AudioClip newClip;
    public float mHorizontal;
    public float mVertical;
    public Vector2 actualNewLoc;

    void Update(){
        mHorizontal = Input.GetAxis("Horizontal");
        mVertical = Input.GetAxis("Vertical");
        if(timeLeft < -9f){
            return;
        }
        if(mHorizontal == 0 && mVertical == 0){
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0){
                cam1.SetActive(false);
                cam2.SetActive(true);
                player.transform.position = actualNewLoc;
                playerRender.sprite = newSprite;
                player.GetComponent<Animator>().SetInteger("State", 3);
                enemy.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                audioS.clip = newClip;
                audioS.Play();
                Destroy(this);
        }

        tasktext.text = timeLeft.ToString("0.00") + task;
        tasktext.gameObject.SetActive(true);

    }

}
