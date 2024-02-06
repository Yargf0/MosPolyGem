using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> eventObjects;
    [SerializeField] private List<GameObject> faileureObjects;
    [SerializeField] private List<Transform> eventPosition;
    [SerializeField] private List<GameObject> eventButton;
    [SerializeField] private List<GameObject> succesfulTexts;
    [SerializeField] private List<GameObject> unsuccesfulTexts;
    [SerializeField] private List<AudioClip> eventFailSound;
    [SerializeField] private List<AudioClip> eventSucsesSound;
    private int activeEventIndex=99;
    private int lastEvent = 5;
    private int withouStudy = 0;
    [SerializeField] private int failTime;
    public bool pressed=false;
    public static Event Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        NewEvent();
    }
    public void NewEvent()
    {
        pressed = false;        
        activeEventIndex = Random.Range(0, eventPosition.Count);
        if (activeEventIndex!=0)
        {
            withouStudy += 1;
        }
        if(withouStudy>=4)
        {
            activeEventIndex = 0;
        }
        if (activeEventIndex==3& lastEvent==0|| (activeEventIndex == 0 & lastEvent == 3))
        {
            NewEvent();
            return;
        }
        if (lastEvent == activeEventIndex)
        {
            NewEvent();
            return;
        }
        lastEvent= activeEventIndex;
        eventButton[activeEventIndex].SetActive(true);
        eventObjects[activeEventIndex].SetActive(true);
        Debug.Log(eventPosition[activeEventIndex].position);
        StudentController.Instance.NewDestenation(eventPosition[activeEventIndex].position);
        Debug.Log("New event " + activeEventIndex);
    }
    public void FailEvent()
    {
        Debug.Log("Event " + activeEventIndex + " faild");
        player.SetActive(false);
        SoundManager.Instance.PlaySound(eventFailSound[activeEventIndex]);
        faileureObjects[activeEventIndex].SetActive(true);
        eventButton[activeEventIndex].SetActive(false);
        unsuccesfulTexts[activeEventIndex].SetActive(true);
        StartCoroutine(whaitFail());
    }
    IEnumerator whaitFail()
    {
        unsuccesfulTexts[activeEventIndex].SetActive(false);
        yield return new WaitForSeconds(failTime);   
        if (activeEventIndex==0)
        {
            Learn.Instance.AddStudy();
        }
        StartCoroutine(whaitNewEvent());
    }
    public void CheckEvent()
    {
        if (!pressed)
        {
            FailEvent();
        }
        else
        {
            succesfulTexts[activeEventIndex].SetActive(true);
            SoundManager.Instance.PlaySound(eventSucsesSound[activeEventIndex]);
            StartCoroutine(whaitNewEvent());
        }        
    }
    IEnumerator whaitNewEvent()
    {
        Debug.Log("Whait for new event");
        faileureObjects[activeEventIndex].SetActive(false);
        eventObjects[activeEventIndex].SetActive(false);
        eventButton[activeEventIndex].SetActive(false);
        player.SetActive(true);
        yield return new WaitForSeconds(5f);
        succesfulTexts[activeEventIndex].SetActive(false);
        NewEvent();
    }
    public int GetEvent()
    {
        return activeEventIndex;
    }
    public void PressButton()
    {
        pressed = true;
        eventObjects[activeEventIndex].SetActive(false);
        eventButton[activeEventIndex].SetActive(false);
    }
}
