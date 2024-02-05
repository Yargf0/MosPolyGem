using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class CloudMessanger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    float TimeToHide = 5.0f;
    private bool IsShowingMessage;
    Timer timer;
    void Start()
    {
        textMeshProUGUI.text = "Привет";
    }
    public void ShowMessage(string message)
    {
        SetActive(true);
        IsShowingMessage=true;
        textMeshProUGUI.text = message;
        SetHideTimer(TimeToHide);
    }
    public void SetActive(bool active)
    {
        if (active)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator SetHideTimer(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        SetActive(false);
        IsShowingMessage = false;
    }

    
}
