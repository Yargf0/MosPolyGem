using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learn : MonoBehaviour
{
    public float MaxStudy = 10;
    public float nowStudy;
    public Image UiStudy;
    public static Learn Instance { get; private set; }

    public void Start()
    {
        Instance = this;
    }
    public void AddStudy()
    {
        Debug.Log(nowStudy);
        nowStudy += 1;
        UiStudy.fillAmount = nowStudy / MaxStudy;
        if (nowStudy >= MaxStudy) 
        {
            Finish();
        }
    }
    public float GetStudy()
    {
        return nowStudy;
    }
    public void Finish()
    {
        EndGame.Instance.End(true);
    }
}
