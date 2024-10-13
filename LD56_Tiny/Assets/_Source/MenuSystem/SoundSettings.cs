using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[RequireComponent (typeof( Slider))]
public class SoundSettings : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string volumeName;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat (volumeName);
        UpdateVolumeOnChange(slider.value);
        slider.onValueChanged.AddListener(delegate { UpdateVolumeOnChange(slider.value); });
    }
    public void UpdateVolumeOnChange(float value)
    {
        if(audioMixer != null)
        {
            PlayerPrefs.SetFloat (volumeName, value);
            audioMixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
        }
        
    }
}
