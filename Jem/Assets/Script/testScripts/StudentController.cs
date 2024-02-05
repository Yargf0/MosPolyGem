using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class StudentController : MonoBehaviour
{
    public NavMeshAgent agent;
    private bool roamingStudent;
    private float currentTime, startTime;
    public Vector3 pointOfInterestOne;
    private bool reachedOne;
    public static StudentController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        startTime = 4;
        roamingStudent = true;
        reachedOne = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            if (roamingStudent)
            {
                Vector2 dot = GetRandomPosition();
                agent.SetDestination(dot);
                roamingStudent = false;
            }
            else if (!roamingStudent)
            {
                agent.SetDestination(pointOfInterestOne);    
            }
            currentTime = startTime;
        }

        if ((float)Math.Round((double)agent.transform.position.x, 4) == (float)Math.Round((double)pointOfInterestOne.x, 4)&& !reachedOne)
        {
            if ((float)Math.Round((double)agent.transform.position.y, 4)  == (float)Math.Round((double)pointOfInterestOne.y, 4) )
            {
                roamingStudent = true;
                reachedOne = true;
                Debug.Log("To Destination");
                Event.Instance.CheckEvent();
            }   
        }
    }

    public void NewDestenation(Vector3 transform)
    {
        transform.z=gameObject.transform.position.z;
        pointOfInterestOne = transform;
        Debug.Log("New destination " + pointOfInterestOne);
        roamingStudent = false;
        reachedOne = false;
    }

    //получение рандомной точки для брожения
    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-4.5f, 6f);
        return new Vector2(x, y);
    }
}
