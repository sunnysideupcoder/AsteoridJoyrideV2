using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundscript : MonoBehaviour
{
    public AudioSource src;
    public AudioClip soundClip;
    public GameObject plane;
    private bool neverDone;
    // Start is called before the first frame update
    void Start()
    {
        //src.Play();
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayExplosion(src);
        /*
        if (!plane.activeInHierarchy)
        {
            if (!neverDone)
            {
                Debug.Log("Explosion!!!");

                src.Play();
                neverDone = true;

            }

        }
        */

    }

    //checks if plane is still alive and plays explosion when its not
    void PlayExplosion(AudioSource src)
    {
        if (!plane.activeInHierarchy)
        {
            if (!neverDone)
            {
                Debug.Log("Explosion!!!");

                src.Play();
                neverDone = true;

            }

        }

    }


}
