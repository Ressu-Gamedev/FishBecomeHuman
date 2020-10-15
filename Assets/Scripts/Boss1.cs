using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Boss1 : Boss
{
    public GameObject player;
    public GameObject cam1;
    public GameObject cam2;
    public int clickCount = 100;
    public string task = " TO GO";
    public TextMeshProUGUI tasktext;

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            clickCount--;
            tasktext.text = clickCount + task;
            tasktext.gameObject.SetActive(true);
            if(clickCount <= 0){
                cam1.SetActive(false);
                cam2.SetActive(true);
                player.transform.position = newLoc;
            }
        }
    }
}
