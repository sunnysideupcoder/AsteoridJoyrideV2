using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    //this code must be changed to assign game object to asteroid when script starts if initial asteroid gets deleted from eventually
    public GameObject Asteroid;
    public float SpawnRate = 200;
    private float timer = 0;
    private Vector3 SpawnerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerPosition = transform.position;

        timer++;

        if (timer > SpawnRate)
        {
            Instantiate(Asteroid,this.transform);
            timer += -2;
        }
        
        
        
    }
}
