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
    [SerializeField] private Animator animator;

    private void Awake()
    {
        Instance = this;
    }

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

        if ((float)Math.Round((double)agent.transform.position.x, 4) == (float)Math.Round((double)pointOfInterestOne.x, 4) && !reachedOne)
        {
            if ((float)Math.Round((double)agent.transform.position.y, 4) == (float)Math.Round((double)pointOfInterestOne.y, 4))
            {
                roamingStudent = true;
                reachedOne = true;
                Debug.Log("To Destination");
                Event.Instance.CheckEvent();
            }
        }

        if (agent.transform.position != agent.destination)
        {
            animator.SetBool("Move", true);
            Vector3 moveDirection = agent.destination - agent.transform.position;
            moveDirection.Normalize();

            if (moveDirection.y > 0)
            {
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
            else if (moveDirection.y < 0) 
            { 
                animator.SetBool("Up", false); 
                animator.SetBool("Down", true); 
                animator.SetBool("Right", false); 
                animator.SetBool("Left", false); 
            }
            else if (moveDirection.x > 0)
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Right", true);
                animator.SetBool("Left", false);
            }
            else if (moveDirection.x < 0)
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", true);
            }
            else
            {
                animator.SetBool("Move", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
    }

    public void NewDestenation(Vector3 transform)
    {
        transform.z = gameObject.transform.position.z;
        pointOfInterestOne = transform;
        Debug.Log("New destination " + pointOfInterestOne);
        roamingStudent = false;
        reachedOne = false;
    }

    //ïîëó÷åíèå ðàíäîìíîé òî÷êè äëÿ áðîæåíèÿ
    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-4.5f, 6f);
        return new Vector2(x, y);
    }
}
