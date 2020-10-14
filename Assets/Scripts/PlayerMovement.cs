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
