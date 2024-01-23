using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;

public class AsteroidSpawnerScript : MonoBehaviour
{
    //this code must be changed to assign game object to asteroid when script starts if initial asteroid gets deleted from eventually
    public GameObject Asteroid;
    private float SpawnRate = 0.22F;
 
    //private float verticalSpawnerSpeed = 5;
    private float timer = 0;
    private Vector3 SpawnerPosition;
    private Vector3 asteroidSpawnPosition;
    private float spawnRange = 35F; //+/- range an asteroid will spawn from the spawner
    public GameObject logic;

    

    //adjust the private field spawn rate
    public void setSpawnRate(float SpawnRate)
    {
        this.SpawnRate = SpawnRate;
    }

    //grab difficulty setting from logic scrip which grabs it from json file
    void Start()
    {
        LogicScript logicScript = logic.GetComponent<LogicScript>();
        
        UpdateSpawnRate(logicScript.difficulty);
        
    }

    // Update is called once per frame
    void Update()
    {

        //this chunk of code spawns Asteroids ; Instantiate create a clone of an object
        SpawnerPosition = transform.position;

        timer += Time.deltaTime;  //counts up in real life time, independent of frame rate

        //Debug.Log("Timer " + timer);
        //Debug.Log("Spawn Rate " + SpawnRate);

        if (timer > SpawnRate)
        {
            //random position for asteroid to spawn in 
            asteroidSpawnPosition = new Vector3(transform.position.x  , transform.position.y + ((Random.value - 0.5F) * spawnRange), transform.position.z);
            Instantiate(Asteroid,asteroidSpawnPosition, this.transform.rotation);
            timer =0;
        }



        
        
        
    }

    private void UpdateSpawnRate(int difficutly)
    {
    
        switch (difficutly)
        {
            case 0:
                SpawnRate = SpawnRate - 0.1F;
                break;
            case 1:
      
                break;
            case 2:
                SpawnRate = SpawnRate + 0.3F;
                break;
            case 3:
                SpawnRate = SpawnRate + 0.6F;
                break;



        }

    }


}
