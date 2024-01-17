using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using System.IO;

public class LogicScript : MonoBehaviour
{
    public GameObject GameOver;
    private float distance;
    public int fps;
    private string SettingsFilepath = Application.dataPath + "/PlayerSettings.json";
    public int difficulty;
    public float sens;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = fps; //sets what frame rate game will try to run at
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
