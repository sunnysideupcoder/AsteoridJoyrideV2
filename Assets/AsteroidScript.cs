using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject Plane;
    // Start is called before the first frame update
    void Start()
    {
        //refering to a specific game object 
        Plane = GameObject.Find("Plane");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //makes asteroids spin
        transform.Rotate(0, 0, 0.5F);

        
        
    }

    //destroy plane when it collides with asteroid
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
     
        if (otherCollider == Plane.GetComponent<Collider2D>())
        {

            Debug.Log("Plane Ran into Asteroid");
            Destroy(otherCollider.gameObject);  //gameObject always refers to the game object that holds this script
        }
    }



}
