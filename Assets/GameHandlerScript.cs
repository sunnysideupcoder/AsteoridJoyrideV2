using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.IsolatedStorage;
using UnityEngine.UIElements;

public class GameHandlerScript : MonoBehaviour
{
    public LogicScript logic;
    private string filepath = Application.dataPath + "/LeaderBoardData.json";
    public int numScores = 10;
    // Start is called before the first frame update
    void Start()
    { 

        Debug.Log("Checking if file exists: " + File.Exists(filepath));

        //checks if Json file with LeaderBoard Data already exists
        // If it doesn't it creats one
        if (!(File.Exists(filepath)))
        {
            Debug.Log("File Created");
            CreateLeaderboard(numScores, filepath);
        }

        /*
        //assinging scores 
        LeaderBoardData leaderBoardData = new LeaderBoardData();
        leaderBoardData.scores[0] = 30;
        leaderBoardData.scores[1] = 20;
        leaderBoardData.scores[2] = 10;

        // creating a json string from game object leaderboard data
        string jsondata = JsonUtility.ToJson(leaderBoardData);
        
        //saving json string to json file
        File.WriteAllText(Application.dataPath + "/LeaderBoardData.json", jsondata);
        
        Debug.Log("Json data" + jsondata);
        //testing update leaderboard with arbitrary 
        //Debug.Log("Updated Leaderboard: " + UpdateLeaderboard(22.0F).scores[1]);

        */
    }

    //creates a json file with leaderboard data with 0s as fields
    public void CreateLeaderboard(int numScores, string filepath)
    {
        //creating leaderboarddata object with appropriate data
        LeaderBoardData leaderBoardData = new LeaderBoardData(numScores);

        for(int i =0; i < numScores; i++)
        {
            leaderBoardData.scores[i] = 0;
        }

        // creating a json string from game object leaderboard data
        string jsondata = JsonUtility.ToJson(leaderBoardData);

        //saving json string to json file
        File.WriteAllText(filepath, jsondata);

        Debug.Log("Json data" + jsondata);
    }


    //Reads Json file containing Leaderboard data and updates it with current score in the appropriate slot
    //also returns updated leader board data object
    public LeaderBoardData UpdateLeaderboard(float currentScore)
    {
        Debug.Log("Update Leader Board  Called");

        //get data from json 
        // sort array 
        //insert new number into array
        // game over scrip should be set up to use the array we're updating after we're finished updating

        
        //string filepath = Application.dataPath + "/LeaderBoardData.json"; use file path from upper variable
       
        string json = File.ReadAllText(filepath);

        Debug.Log("Json string: " + json);
        LeaderBoardData loadedData = JsonUtility.FromJson<LeaderBoardData>(json);  // converts json string from file to LeaderBoard Data object




         //stuff that puts current score into right place

        //maybe we don't need to sort it immidietly since it should be sorted already
        //checking if this runs score would even make top 10
        if (currentScore > loadedData.scores[loadedData.scores.Length -1])
        {
            Debug.Log("last score: " + loadedData.scores[loadedData.scores.Length - 1]);
            
            //Loop through top scores to find the highest score current score is greater than
            for (int i = 0; i < loadedData.scores.Length; i++)
            {
                
                if(currentScore >= loadedData.scores[i])
                {
                    //once right place for current score is found; the following for loop will shift all values to the right one place and then place current score in the appropriate place
                    for (int j = loadedData.scores.Length -1; j > i; j--)
                    {
                        loadedData.scores[j] = loadedData.scores[j-1];

                    }

                    //replace value that current score was greater than by current score
                    loadedData.scores[i] = currentScore;

                    break; // needed otherwise the for loop will continue for every score lower than this

                }
            }

        }


        //this next part writes our updates array into the save file
        //converts our object to json string and then writes that into file

        string jsonUpdated = JsonUtility.ToJson(loadedData);
        File.WriteAllText(filepath, jsonUpdated);

        return loadedData;



    }

    //simple LeaderBoard Data class used to convert to and from json files
    //single constructor to specify number of scores stored in json file
    public class LeaderBoardData
    {
        private int NumScores;
        public float[] scores;

        public LeaderBoardData(int NumScores)
        {
            this.NumScores = NumScores; //set the class field NumScores equal to the argument NumScores
            scores = new float[NumScores];
        }

        public int getNumScores()
        {
            return NumScores;
        }

        
    }

    private void test()
    {

    }

    /*
     LeaderBoardData UpdateLeaderboard(float currentScore)
    {
        Debug.Log("Update Leaderboard initiated");

        //get data from json 
        // sort array 
        //insert new number into array
        // game over scrip should be set up to use the array we're updating after we're finished updating

        string filepath = Application.dataPath + "/LeaderBoardData.json";
       
        string json = File.ReadAllText(filepath);

        Debug.Log("Json string: " + json);
        LeaderBoardData loadedData = JsonUtility.FromJson<LeaderBoardData>(json);  // converts json string from file to LeaderBoard Data object

        //Debug.Log("Loaded data " + loadedData);
        Debug.Log("Loaded date " + loadedData.scores[0]);
        Debug.Log("Loaded date " + loadedData.scores[1]);
        Debug.Log("Loaded date " + loadedData.scores[2]);



         //stuff that puts current score into right place

        //maybe we don't need to sort it immidietly since it should be sorted already
        //checking if this runs score would even make top 10
        if (currentScore > loadedData.scores[loadedData.scores.Length -1])
        {
            Debug.Log("first If statment activated");
            //code to put current score in the right place
            for (int i = 0; i < loadedData.scores.Length; i++)
            {
                // need something that will break the loop after the first time
                if(currentScore >= loadedData.scores[i])
                {
                    Debug.Log("second If statment activated for i: " + i);
                    
                    // for loop that schooches all other values down one 
                    for (int j = i; j< loadedData.scores.Length-1; j++)
                    {
                        loadedData.scores[j+1] = loadedData.scores[j];
                        Debug.Log("j: " + j + " = " + loadedData.scores[j]);
            
                    }
                    //replace value that current score was greater than by current score
                    loadedData.scores[i] = currentScore;

                    break; // needed otherwise the for loop will continue for every score lower than this

                }
            }

        }
        // else do nothing because it's not going to be in the leaderboard


        


        Debug.Log(loadedData.scores[0]);
        Debug.Log(loadedData.scores[1]);
        Debug.Log(loadedData.scores[2]);

        return loadedData;



    }
     */

}
