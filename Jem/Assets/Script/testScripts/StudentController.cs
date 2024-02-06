using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StudentController : MonoBehaviour
{
    public NavMeshAgent agent;
    private bool roamingStudent;
    private float currentTime, startTime;
    public Transform pointOfInterestOne;
    public Transform pointOfInterestTwo;
    private bool reachedOne, reachedTwo;
    /* «десь можно реализовать логику выбора точки интереса
    private bool firstPointBlocked;
    private bool secondPointBlocked;
    private bool firstPointDone;
    private bool secondPointDone;*/

    void Start()
    {
        startTime = 4;
        roamingStudent = true;
        reachedOne = false;
        reachedTwo = false;
    }
    /// <summary>
    /// ¬ апдейте по таймеру персонаж перемещаетс€ от точки до точки, 
    /// если roamingStudent, персонаж просто гул€ет,
    /// если нет, персонаж идет к точке интереса.
    /// ≈сли точка достигнута, roamingStudent снова тру,
    /// а персонаж идет бродить.
    /// </summary>
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
                var rand = Random.Range(0, 2);
                switch (rand)
                {
                    case 0:
                        agent.SetDestination(pointOfInterestOne.position);
                        break;

                     case 1:
                        agent.SetDestination(pointOfInterestTwo.position);
                        break;
                }
            }
            currentTime = startTime;
        }

        if (agent.transform.position == pointOfInterestOne.position)
        {
            roamingStudent = true;
            reachedOne = true;
            Debug.Log("reached 1");
        }
        else if (agent.transform.position == pointOfInterestTwo.position)
        {
            roamingStudent = true;
            reachedTwo = true;
            Debug.Log("Reached 2");
        }

    }

    //получение рандомной точки дл€ брожени€
    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-4.5f, 6f);
        return new Vector2(x, y);
    }
}
