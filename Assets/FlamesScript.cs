using System.Collections;
using System.Collections.Generic;
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
        moveHorizontally();
        
    }

    public void moveHorizontally()
    {
        float speed = 5F;
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Collision");
            Destroy(collision.gameObject);  //gameObject always refers to the game object that holds this script
        }
    }

}
