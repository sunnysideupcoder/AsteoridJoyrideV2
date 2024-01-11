using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Threading;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverObj;
    public GameObject HorizontalObj;
    public TextMeshProUGUI ScoreText;   //had to assign it as Text Object to be able to access specific methods
    GameObject plane;
    public LogicScript Logic;
    public int count = 0;
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<LogicScript>();
        //Debug.Log("Game Over script started");
        GameOverObj = GameObject.Find("GameOverScreen");

        //Change "Score" only when this is fist called so it stays in the position logic had right when the game ended aka right when this screen is activated
        UpdateScore();

    }

    // Update is called once per frame
    void Update()
    {
        //this checks if the plane is still alive and the moment it dies it activates the game over screen
        plane = GameObject.Find("Plane");


        if (plane == null)
        {
            Logic.gameOver();
        }

    }
    public void GameRestart()
    {
        // loads scene "Game", defined like this for more modularity
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

    //method to change score on display screen, uses distance covered method from logic object
    void UpdateScore()
    {
        float distance = Logic.distanceCovered();
        String display = String.Format("Score: {0:F2} meters!!!", distance);
        ScoreText.SetText(display);  

    }


}
