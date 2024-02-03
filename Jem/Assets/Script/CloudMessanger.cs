using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class CloudMessanger : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    Timer timer;
    void Start()
    {
        textMeshProUGUI.text = "������";
    }
    public void ShowMessage(string message)
    {
        textMeshProUGUI.text = message;
        //SetHideTimer(5.0);
    }
    IEnumerator SetHideTimer(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        //������� ������
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            this.gameObject.SetActive(true);
        }else
        {
            this.gameObject.SetActive(false);
        }
    }
}
