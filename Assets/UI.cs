//script to show score on overlay while you're in the run
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public LogicScript Logic;
    public TextMeshProUGUI ScoreText;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = (int)Logic.distanceCovered();
        string display = string.Format(distance + "");
        ScoreText.SetText(distance + "");

        // so when game over screen pops up the current score isnt displayed twice
        if(gameOverScreen.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
