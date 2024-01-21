using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundscript : MonoBehaviour
{
    public AudioSource src;
    public AudioSource gameMusic;
    public GameObject plane;
    public GameObject gameOverScreen;
    private bool neverDone;
    private bool neverDoneMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        gameMusic.loop = true; //repeats the audio clip until its stopped

    }

    // Update is called once per frame
    void Update()
    {
        PlayExplosion(src);

        //plays music while game is happening
        if (!gameOverScreen.activeInHierarchy)
        {
            if (!neverDoneMusic)
            {
                

                gameMusic.Play();
                neverDoneMusic = true;

            }
        //when game over screen appers it resets neverDoneMusic so next run it starts the music over and stops the music
        }
        else
        {
            neverDoneMusic = false;
            gameMusic.Stop();

        }


    }

    //checks if plane is still alive and plays explosion when its not
    void PlayExplosion(AudioSource src)
    {
        if (!plane.activeInHierarchy)
        {
            if (!neverDone)
            {
                

                src.Play();
                neverDone = true;

            }

        }

    }




}
