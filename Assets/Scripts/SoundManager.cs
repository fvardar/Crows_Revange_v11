using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioSource Asource;
    public static AudioClip jumpsound, walksound, swordsound, arrowsound, deathsound,fireballsound;
    private float soundvolume;


    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();

        soundvolume = PlayerPrefs.GetFloat("soundvol");
        

        jumpsound = Resources.Load<AudioClip>("Sounds/jump");
        walksound = Resources.Load<AudioClip>("Sounds/walk");
        swordsound = Resources.Load<AudioClip>("Sounds/sword");
        arrowsound = Resources.Load<AudioClip>("Sounds/arrow");
        deathsound = Resources.Load<AudioClip>("Sounds/death");
        fireballsound = Resources.Load<AudioClip>("Sounds/fireball");
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = soundvolume;
        Asource.volume = soundvolume;
    }
    public void SetVolume(float vol)
    {
        soundvolume = vol;
        PlayerPrefs.SetFloat("soundvol", vol);
    }
    public void Mute_Unmute_Sounds()
    {
        if (AudioListener.volume > 0f)
        {
            soundvolume = 0f;
            PlayerPrefs.SetFloat("soundvol", 0f);
        }
        else if (AudioListener.volume == 0f)
        {
            soundvolume = 1f;
            PlayerPrefs.SetFloat("soundvol", 1f);
        }
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                Asource.PlayOneShot(jumpsound);
                break;
            case "arrow":
                Asource.PlayOneShot(arrowsound);
                break;
            case "sword":
                Asource.PlayOneShot(swordsound);
                break;
            case "death":
                Asource.PlayOneShot(deathsound);
                break;
            case "fireball":
                Asource.PlayOneShot(fireballsound);
                break;
        }
    }
    public static void WalkSound()
    {
        Asource.clip = walksound;
        Asource.Play();
    }
    public static void StopWalk()
    {
        Asource.Stop();
        Asource.clip = null;
    }
}
