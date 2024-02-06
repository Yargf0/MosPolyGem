using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    private int activeEventIndex=99;
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
        activeEventIndex = Random.Range(0, eventPosition.Count - 1);        
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
        faileureObjects[activeEventIndex].SetActive(true);
        eventButton[activeEventIndex].SetActive(false);
        unsuccesfulTexts[activeEventIndex].SetActive(true);
        StartCoroutine(whaitFail());
    }
    IEnumerator whaitFail()
    {
        yield return new WaitForSeconds(failTime);
        unsuccesfulTexts[activeEventIndex].SetActive(false);
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
