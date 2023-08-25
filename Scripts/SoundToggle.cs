using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private GameObject[] audioSources;
    [SerializeField] private bool isMusicToggle;

    [SerializeField] Toggle toggle;


    private void Awake()
    {
        if (!isMusicToggle)
        {
            int savedHandValue = PlayerPrefs.GetInt("EffectToggle", 1);
            toggle.isOn = savedHandValue == 1;
        }
        else
        {
            int savedHandValue = PlayerPrefs.GetInt("MusicToggle", 1);
            toggle.isOn = savedHandValue == 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMusicToggle)
        {
            audioSources = GameObject.FindGameObjectsWithTag("Effect");
            if (toggle.isOn)
            {
                PlayerPrefs.SetInt("EffectToggle", 1);
            }
            else
            {
                PlayerPrefs.SetInt("EffectToggle", 0);
            }
        }
        else
        {
            audioSources = GameObject.FindGameObjectsWithTag("Music");
            if (toggle.isOn)
            {
                PlayerPrefs.SetInt("MusicToggle", 1);
            }
            else
            {
                PlayerPrefs.SetInt("MusicToggle", 0);
            }
        }



        foreach (GameObject gameObject in audioSources)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>(); 
            if (source != null)
            {
                source.mute = !toggle.isOn;
            }
        }
    }
}
