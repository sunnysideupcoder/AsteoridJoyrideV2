using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using System.IO;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject GameOver;
    private float distance;
    public int fps;
    private string SettingsFilepath = Application.dataPath + "/PlayerSettings.json";
    public int difficulty;
    public float sens;
    private Controls PlayerControls;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = fps; //sets what frame rate game will try to run at

        PlayerControls = new Controls();
    }

    
    //player controls here so we can press escape key to leave even when plane is dead

    private void OnEnable()
    {
        PlayerControls.Enable();

    }

    private void OnDisable()
    {
        PlayerControls.Disable();

    }

    private void Update()
    {
        // CHATGPT code to convert float value to bool 
        float escapeValue = PlayerControls.Plane.Escape.ReadValue<float>();
        bool escape = Mathf.Approximately(escapeValue, 1.0f);

        //control escape key
        if (escape)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void Start()
    {
        //import values from object to change settings
        string json = File.ReadAllText(SettingsFilepath);
        PlayerSetting playerSetting = JsonUtility.FromJson<PlayerSetting>(json);
        //change spawn rate based of selected difficulty
        difficulty = playerSetting.difficulty;
        sens = playerSetting.sensativity;

    }

    public class PlayerSetting
    {
        public int difficulty;
        public float sensativity;


    }

    //repositions game over screen to be on top of logicscript and activates it
    public void gameOver()
    {
        GameOver.transform.position = transform.position;
        GameOver.SetActive(true);
    }

    public float distanceCovered()
    {
        return distance = transform.position.x;
    }


}
