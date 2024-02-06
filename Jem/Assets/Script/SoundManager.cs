using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] 
    AudioSource audioData;[SerializeField] 
    AudioSource audioBack;
    [SerializeField] private List<AudioClip> music;
    private float volume;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        audioData = GetComponent<AudioSource>();
        if(audioData != null ) { UnityEngine.Debug.Log("SoundManager started"); }
        else { UnityEngine.Debug.Log("SoundManager false"); }
        audioData.volume = PlayerPrefs.GetFloat("volume");
        audioData.Play();
        playBack(0);
    }
    public void playBack(int a)
    {
        audioBack.clip = music[a];
        audioBack.Play();
        audioBack.loop = true;
    }
    public void StopSound()
    {
        audioData.Stop();
    }
    public void VolumeChanged()
    {

        audioData.volume = PlayerPrefs.GetFloat("volume");

        audioBack.volume = PlayerPrefs.GetFloat("volume")/2;
    }
    public void PlaySound(AudioClip newClip)
    {
        audioData.PlayOneShot(newClip, audioData.volume);
    }
    public void PlayRepeatSound(string sound)
    {
        //List<AudioClip> audioClips = SoundList[sound];
        //if (audioClips == null) { UnityEngine.Debug.LogError($"Звуки {sound} не найдены"); return; }
        //AudioClip newClip = GetRandomClip(audioClips);
        //audioData.clip = newClip;
        //audioData.loop = true;
        //audioData.Play();
    }
    private AudioClip GetRandomClip(List<AudioClip> audioClipArray)
    {
        AudioClip newClip= audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Count)];
        if (newClip == null) { UnityEngine.Debug.LogError($"Ошибка при выборе случайного звука из списка"); return null; }
        return newClip;
    }
}
