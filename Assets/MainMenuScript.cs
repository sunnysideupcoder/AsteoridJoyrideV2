using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameHandlerScript;

public class MainMenuScript : MonoBehaviour
{
    //public GameObject AsteroidSpawner;
    private string SettingsFilepath = Application.dataPath + "/PlayerSettings.json";


    

    //File.Exists(SettingsFile)


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main Menu Script started, FilePath:" + SettingsFilepath);
        PlayerSetting playerSetting = new PlayerSetting();

        //updateSettignsFile
        //read contents of file into json string 
        //use from json to make string into object 

        // if no file exists //create settings file
        if ((!File.Exists(SettingsFilepath)))
        {
            Debug.Log("Player Settings Json file created");
            CreateSettings(SettingsFilepath, playerSetting);

            
        }






            // JsonUtility.FromJson<PlayerSetting>()
    }

   //updates settings json file using argument values
    public void UpdateSettings(string filepath, int difficulty)
    {
        Debug.Log("Update settings invoked");
        //opening settings file and making it an object
        string json = File.ReadAllText(filepath);


        PlayerSetting loadedData = JsonUtility.FromJson<PlayerSetting>(json);

        //adjust settings in object
        loadedData.setDifficulty(difficulty);
        //loadedData.setSensativity(sensativity);

        //write this back into file

        string JsonUpdated = JsonUtility.ToJson(loadedData);
        File.WriteAllText(filepath, JsonUpdated);

    }

    //overloaded method to change sens
    public void UpdateSettings(string filepath,  float sensativity)
    {
        Debug.Log("Update settings invoked");
        //opening settings file and making it an object
        string json = File.ReadAllText(filepath);


        PlayerSetting loadedData = JsonUtility.FromJson<PlayerSetting>(json);

        //adjust settings in object
        //loadedData.setDifficulty(difficulty);
        loadedData.setSensativity(sensativity);

        //write this back into file

        string JsonUpdated = JsonUtility.ToJson(loadedData);
        File.WriteAllText(filepath, JsonUpdated);

    }



    //creates a json file with settings from playerSettings object, sets default settings
    public void CreateSettings(string filepath, PlayerSetting playerSetting)
    {
        Debug.Log("Create Settings invoked");
        //set default settings in object
        playerSetting.setSensativity(1);
        playerSetting.setDifficulty(0);

        //Debug.Log("Updated sens" + playerSetting.getSensativity());
        //Debug.Log("Updated difficulty" + playerSetting.getDifficulty());


        //convert settings object to json string

        string jsondata = JsonUtility.ToJson(playerSetting); ;

        //saving json string to json file
        File.WriteAllText(filepath, jsondata);

        Debug.Log("Json data" + jsondata);

        

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

    //have to go back and change this to not set sensativity
    public void ChangeDifficulty(int difficulty)
    {
        

        if (difficulty == 0)
        {
            // AsteroidSpawnerScript.setSpawnRate(0);
            Debug.Log("Difficutly changed: " + difficulty);
            UpdateSettings(SettingsFilepath, 0);
            
            
            
        }
        else if (difficulty == 1)
        {
            Debug.Log("Difficutly changed: " + difficulty);
            //AsteroidSpawnerScript.setSpawnRate(0.22F + 0.1F);
            UpdateSettings(SettingsFilepath, 1);
        }
        else if (difficulty == 2)
        {
            Debug.Log("Difficutly changed: " + difficulty);
            //AsteroidSpawnerScript.setSpawnRate(0.22F - 0.1F);
            UpdateSettings(SettingsFilepath, 2);

        }

    }

    public class PlayerSetting
    {
        public int difficulty;
        public float sensativity;

        public void setDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
        }
        public int getDifficulty()
        {
            return difficulty;
        }


        public void setSensativity(float sensativity)
        {
            this.sensativity = sensativity;
        }

        public float getSensativity()
        {
            return sensativity;
        }
    }
}
