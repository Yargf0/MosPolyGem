using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(VolumeChanged);
        slider.value = PlayerPrefs.GetFloat("volume");
    }
    private void VolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        SoundManager._i.VolumeChanged();
    }
}
