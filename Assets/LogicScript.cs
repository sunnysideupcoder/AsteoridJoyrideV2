using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public GameObject GameOver;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
