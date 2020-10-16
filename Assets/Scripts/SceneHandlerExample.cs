using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You will need to write either of these if you wish to write your own code when using UI, or managing a scene
using UnityEngine.UI; // This allows you to edit UI elements which mostly include presenting: Score/Points, Timer, HealthBar
using UnityEngine.SceneManagement; // This allows you to control your scene such as Pausing, going to your Main Menu, or reseting a level

public class SceneHandlerExample : MonoBehaviour
{
    public Text curState;
    private bool isPaused;
    public GameObject pScreen;

    // Start is called before the first frame update
    void Start()
    {
        pScreen.SetActive(isPaused);
    }

    public void GO()
    {
        StartCoroutine(GameOver());
    }
    public void PauseGame()
    {
        if(!isPaused)
        {
            Time.timeScale = 0f;
            curState.text = "Paused";
            //isPaused = true;
        }
        else
        {

            Time.timeScale = 1f;
            curState.text = "";
            //isPaused = false;
        }
        isPaused = !isPaused;
        pScreen.SetActive(isPaused);
    }
    public IEnumerator GameOver()
    {
        yield return null;
        PauseGame();
        curState.text = "GameOver!";
        yield return new WaitForSecondsRealtime(2f);
        
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }
    }
}
