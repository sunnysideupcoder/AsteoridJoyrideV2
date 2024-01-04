using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Game started");
        SceneManager.LoadScene("Game");



    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
