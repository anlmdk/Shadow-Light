using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource soundSource;

    void Start()
    {
        DontDestroyOnLoad(this);

        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        soundSource.volume = savedVolume;
        volumeSlider.value = savedVolume;


        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
    }

    void SetVolume()
    {
        soundSource.volume = volumeSlider.value;

        PlayerPrefs.SetFloat("Volume", soundSource.volume);
        PlayerPrefs.Save();
    }
}
