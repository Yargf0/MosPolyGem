using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learn : MonoBehaviour
{
    public int MaxStudy = 10;
    public int nowStudy;
    public Image UiStudy;

    public void AddStudy()
    {
        nowStudy += 1;
        UiStudy.fillAmount = nowStudy / MaxStudy;
        if (nowStudy >= MaxStudy) 
        {
            Finish();
        }
    }
    public int GetStudy()
    {
        return nowStudy;
    }
    public void Finish()
    {
        
    }
}
