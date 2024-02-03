using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] 
    SoundDict soundDict;
    Dictionary<string, List<AudioClip>> SoundList;

    AudioSource audioData;  
    private float volume;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        if(audioData != null ) { UnityEngine.Debug.Log("SoundManager started"); }
        else { UnityEngine.Debug.Log("SoundManager false"); }
        //volume = PlayerPrefs.GetFloat("volume");
        SoundList = soundDict.ToDictionary();
    }
    public void PlaySound(string sound)
    {
        List<AudioClip> audioClips = SoundList[sound];
        if( audioClips == null ) { UnityEngine.Debug.LogError($"Звуки {sound} не найдены");return; }
        AudioClip newClip = GetRandomClip(audioClips);
       // audioData.PlayOneShot(newClip, volume); 
        audioData.PlayOneShot(newClip); 
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
