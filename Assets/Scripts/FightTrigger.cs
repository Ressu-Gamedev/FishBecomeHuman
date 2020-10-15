using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;
    public Boss bossScript;
    public Vector2 newLoc;
    public Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            bossScript.newLoc = collision.transform.position;
            collision.transform.position = newLoc;
            Destroy(this);
        }
    }
}
