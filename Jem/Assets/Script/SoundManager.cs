using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager _i { get; private set; }
    [SerializeField] 
    SoundDict soundDict;
    Dictionary<string, List<AudioClip>> SoundList;
    AudioSource audioData;  
    private float volume;
    void Start()
    {
        _i = this;
        audioData = GetComponent<AudioSource>();
        if(audioData != null ) { UnityEngine.Debug.Log("SoundManager started"); }
        else { UnityEngine.Debug.Log("SoundManager false"); }
        audioData.volume = PlayerPrefs.GetFloat("volume");
        SoundList = soundDict.ToDictionary();
    }
    public void VolumeChanged()
    {
        audioData.volume = PlayerPrefs.GetFloat("volume");
    }
    public void PlaySound(string sound)
    {
        List<AudioClip> audioClips = SoundList[sound];
        if( audioClips == null ) { UnityEngine.Debug.LogError($"Звуки {sound} не найдены");return; }
        AudioClip newClip = GetRandomClip(audioClips);
        audioData.PlayOneShot(newClip);
    }
    public void PlayRepeatSound(string sound)
    {
        List<AudioClip> audioClips = SoundList[sound];
        if (audioClips == null) { UnityEngine.Debug.LogError($"Звуки {sound} не найдены"); return; }
        AudioClip newClip = GetRandomClip(audioClips);
        audioData.clip = newClip;
        audioData.loop = true;
        audioData.Play();
    }
    private AudioClip GetRandomClip(List<AudioClip> audioClipArray)
    {
        AudioClip newClip= audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Count)];
        if (newClip == null) { UnityEngine.Debug.LogError($"Ошибка при выборе случайного звука из списка"); return null; }
        return newClip;
    }
}
[Serializable]
public class SoundDict
{
    [SerializeField]
    SoundDictItem[] SoundClips;
    public Dictionary<string,List<AudioClip>> ToDictionary()
    {
        Dictionary<string, List<AudioClip>> newDict= new Dictionary<string, List<AudioClip>>();
        foreach(var item in SoundClips)
        {
            newDict[item.SoundName] = item.SoundClips;
        }
        return newDict;
    }
}
[Serializable]
public class SoundDictItem
{
    [SerializeField]
    public string SoundName;
    [SerializeField]
    public List<AudioClip> SoundClips;
}
