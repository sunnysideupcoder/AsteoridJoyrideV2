using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;
    private string vol = "musicVolume";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("sound manager started");
        
        
        if (!(PlayerPrefs.HasKey(vol)))
        {
            //Debug.Log("no music volume" + PlayerPrefs.GetFloat(vol));
            PlayerPrefs.SetFloat("musicVolume", 1.0F);
            load();
        }
        else
        {
            load();
        }
        

    }



    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }


    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(vol);
    }

    private void save()
    {
        PlayerPrefs.SetFloat(vol, volumeSlider.value);
    }


}
