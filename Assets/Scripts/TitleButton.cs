using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public float timeElapsed = 0f;
    public float initialY;

    void Start(){
        initialY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.position = new Vector2(0f, initialY + (float) Math.Sin(timeElapsed));
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Swimming", LoadSceneMode.Single);
        }
    }
}
