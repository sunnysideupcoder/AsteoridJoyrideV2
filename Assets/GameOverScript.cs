using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverObj;
    public GameObject HorizontalObj;
    GameObject plane;
    public LogicScript Logic;
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<LogicScript>();
        Debug.Log("Game Over script started");
        GameOverObj = GameObject.Find("GameOverScreen");
        //Debug.Log(GameOverObj.name);
    }

    // Update is called once per frame
    void Update()
    {
        //this checks if the plane is still alive and the moment it dies it activates the game over screen
        plane = GameObject.Find("Plane");


        if (plane == null)
        {
            
            Debug.Log("PLane nUll game over");
            Logic.gameOver();
        }

    }
    public void GameRestart()
    {
        // loads scene "Game", defined like this for more modularity
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    } 



}
