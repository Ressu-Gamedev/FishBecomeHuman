using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // These are used by the animation system
    public float mHorizontal;
    public float mVertical;
    public float speed;
    public float scaleX;
    public float scaleY;
    public int lastDirection = 1;
    public float lastScale = 1f;
    public int achievedMax = 0;
    public AudioSource theBeans;
    public AudioClip[] allMyHomiesEatBeans;
    public AudioClip[] allMyHomiesEatCheese;
    public AudioClip[] allMyHomiesEatSoy;
    public float dTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        mHorizontal = Input.GetAxis("Horizontal");
        mVertical = Input.GetAxis("Vertical");

        // Hacky code to flip the player when they're facing left/right
        if(mHorizontal != 0f && Math.Sign(mHorizontal) != lastDirection && Math.Abs(mHorizontal) > lastScale){
            transform.localScale = new Vector2(mHorizontal * scaleX, scaleY);
            if(Math.Abs(mHorizontal) == 1f){
                achievedMax = 1;
            }else{
                achievedMax = -1;
            }
        }
        if(mHorizontal == 0f && achievedMax == -1){
            transform.localScale = new Vector2(-lastDirection * scaleX, scaleY);
            achievedMax = 0;
            lastDirection = -lastDirection;
        }
        if(Math.Abs(mHorizontal) == 1f){
            lastDirection = Math.Sign(mHorizontal);
        }
        
        lastScale = Math.Abs(mHorizontal);

        // Sound effect bs handling smile
        dTime += Time.deltaTime;
        if((mHorizontal != 0f || mVertical != 0f) && dTime > 2f){
            AudioClip singularBean = allMyHomiesEatBeans[UnityEngine.Random.Range(0, allMyHomiesEatBeans.Length)];
            AudioClip singularBean2 = allMyHomiesEatSoy[UnityEngine.Random.Range(0, allMyHomiesEatSoy.Length)];
            theBeans.PlayOneShot(singularBean, 1.5f);
            theBeans.PlayOneShot(singularBean2, 0.6f);
            dTime = 0f;
        }
    }

    // All physics operations
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 movement = new Vector2(mHorizontal, mVertical);
        rb.velocity = (movement * speed * Time.deltaTime);
    }
}
