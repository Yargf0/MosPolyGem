using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject slider;
    void Start()
    {
        slider.GetComponent<Slider>().onValueChanged.AddListener(VolumeChanged);
        float i =PlayerPrefs.GetFloat("volume");
        if (i >=0)
            slider.GetComponent<Slider>().value = i;
        else
            slider.GetComponent<Slider>().value = 0.5f;
    }
    public void VolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        SoundManager.Instance.VolumeChanged();
    }
    public void OpenSetting() 
    {
        setting.SetActive(true);
    }
    public void CloseSetting()
    {
        setting.SetActive(false);    
    }
}
