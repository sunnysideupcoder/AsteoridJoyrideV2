using UnityEngine;

// detects when any object collides with 
public class BarricadeScript : MonoBehaviour
{
    private PlaneMovement Plane;
    

    private void OnTriggerEnter2D(Collider2D plane)
    {
        Plane = GameObject.Find("Plane").GetComponent<PlaneMovement>();
        Plane.align(); 
   
    }
}
