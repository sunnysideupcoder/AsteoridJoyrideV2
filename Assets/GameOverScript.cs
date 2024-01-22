using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Threading;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverObj;
    public GameObject HorizontalObj;
    public TextMeshProUGUI ScoreText;   //had to assign it as Text Object to be able to access specific methods
    GameObject plane;
    public GameObject LogicObject;
    public LogicScript Logic;
    
    
    public GameHandlerScript GameHandler;
    public TextMeshProUGUI LeaderText;
    void Start()
    {
        
        GameOverObj = GameObject.Find("GameOverScreen");

        GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandlerScript>();

        

        Logic = GameObject.Find("Logic").GetComponent<LogicScript>();


        //Change "Score" only when this is fist called so it stays in the position logic had right when the game ended aka right when this screen is activated
        UpdateScore();
        UpdateLeaderBoardText();
        
        
        
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

    
    private void UpdateLeaderBoardText()
    {
        
        float currentScore = Logic.distanceCovered();
        GameHandlerScript.LeaderBoardData leaderBoard = GameHandler.UpdateLeaderboard(currentScore, Logic.difficulty);

        //this part makes a very long string by referecing the different parts of the leaderboard scores array then sets the text of the object
        string LeaderBoardStr = "Top Scores!!\n";
        int count = GameHandler.numScores;
        for(int i  = 0; i < count; i++)
        {
            //LeaderBoardStr = LeaderBoardStr + String.Format( "{0,-10} {1,-25:F2} {2,-10}\n" ,i+1, leaderBoard.scores[i] , "m");
            LeaderBoardStr = LeaderBoardStr + String.Format(i+1 + ") {0, 0:F2} {1}\n", leaderBoard.scores[i], "m");

        }

        LeaderText.SetText(LeaderBoardStr);


    }


    


}
