using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject allEnding;
    [SerializeField] private GameObject loxEnding;
    [SerializeField] private GameObject goodEnding;
    [SerializeField] private bool howEnd;
    [SerializeField] private GameObject chara;
    public static EndGame Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    public void End(bool i)
    {
        howEnd = i;
        chara.SetActive(false);
        allEnding.SetActive(true);
    }
    public void ShowNextImage()
    {
        allEnding.SetActive(false);
        if (howEnd)
        {
            goodEnding.SetActive(true);
        }
        else
        {
            loxEnding.SetActive(true);
        }
    }
    public void ShowLast()
    {
        LoadSceneExit.Instance.LoadScene("Menu");
    }
}