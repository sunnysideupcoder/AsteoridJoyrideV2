using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontally : MonoBehaviour
{
    GameObject[] barriers;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        barriers = GameObject.FindGameObjectsWithTag("HorizontalMotion");

        

        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < barriers.Length; i++)
        {
            moveHorizontally(barriers[i]);
        }
       
        
    }

    public void moveHorizontally(GameObject obj)
    {
        
        obj.transform.position = obj.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
