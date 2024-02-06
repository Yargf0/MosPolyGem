using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] 
    AudioSource audioData;  
    private float volume;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        audioData = GetComponent<AudioSource>();
        if(audioData != null ) { UnityEngine.Debug.Log("SoundManager started"); }
        else { UnityEngine.Debug.Log("SoundManager false"); }
        audioData.volume = PlayerPrefs.GetFloat("volume");
    }
    public void VolumeChanged()
    {
        audioData.volume = PlayerPrefs.GetFloat("volume");
    }
    public void PlaySound(AudioClip newClip)
    {
        audioData.PlayOneShot(newClip, audioData.volume);
    }
    private AudioClip GetRandomClip(List<AudioClip> audioClipArray)
    {
        AudioClip newClip= audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Count)];
        if (newClip == null) { UnityEngine.Debug.LogError($"������ ��� ������ ���������� ����� �� ������"); return null; }
        return newClip;
    }
}
