using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlamesScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider != null)
        {
            //Debug.Log("Collision");
            //Destroy(otherCollider.gameObject);  //gameObject always refers to the game object that holds this script

            otherCollider.gameObject.SetActive(false);
        }
    }

}
