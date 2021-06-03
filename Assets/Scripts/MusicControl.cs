using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private static AudioSource Asource;
    private float musicvolume;
    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();

        musicvolume = PlayerPrefs.GetFloat("musicvol");
        Asource.volume = musicvolume;
    }

    // Update is called once per frame
    void Update()
    {
        Asource.volume = musicvolume;
    }
    public void SetMusicVol(float vol)
    {
        musicvolume = vol;
        PlayerPrefs.SetFloat("musicvol", vol);
    }
    public void Mute_Unmute_Music()
    {
        if (Asource.volume > 0f)
        {
            musicvolume = 0f;
            PlayerPrefs.SetFloat("musicvol", 0f);
        }
        else if (Asource.volume == 0f)
        {
            musicvolume = 1f;
            PlayerPrefs.SetFloat("musicvol", 1f);
        }
    }
}
