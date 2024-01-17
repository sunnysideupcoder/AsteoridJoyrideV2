using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject Plane;
    public float spinRate;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //refering to a specific game object 
        Plane = GameObject.Find("Plane");
        
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, spinRate*Time.deltaTime);

        //asteroids move left so ship doesnt have to move as fast
        //transform.position = obj.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);

    }




    //destroy plane when it collides with asteroid
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("COLLISION");

        if (otherCollider == Plane.GetComponent<PolygonCollider2D>())
        {
            //gameObject always refers to the game object that holds this script
            otherCollider.gameObject.SetActive(false);
        }
    }



}
