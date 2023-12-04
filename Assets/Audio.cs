using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource soundSource;

    void Start()
    {
        DontDestroyOnLoad(this);

        // Match the initial volume of the sound source with the slider value
        soundSource.volume = volumeSlider.value;

        // Add a listener to the slider's value changed event
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
    }

    void SetVolume()
    {
        // Update the volume of the sound source with the slider value
        soundSource.volume = volumeSlider.value;
    }
}
