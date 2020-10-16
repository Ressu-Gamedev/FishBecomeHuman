using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextFlash : MonoBehaviour
{
    public TextMeshProUGUI curState;
    public float elapsedTime;
    public float flashSpeed = 20f;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 3f || (int)(elapsedTime * flashSpeed) % 2 == 0){
            curState.enabled = true;
        }else{
            curState.enabled = false;
        }
    }
}
