using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontally : MonoBehaviour
{
    GameObject[] barriers; 

    // Start is called before the first frame update
    void Start()
    {
        barriers = GameObject.FindGameObjectsWithTag("HorizontalMotion");
        Debug.Log(barriers);
        if (barriers == null)
        {
            Debug.Log("couldnt find tag horizonatl motion");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < barriers.Length; i++)
        {
            moveHorizontally(barriers[i]);
        }
       
        Debug.Log("Hello");
    }

    public void moveHorizontally(GameObject obj)
    {
        float speed = 5F;
        obj.transform.position = obj.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
