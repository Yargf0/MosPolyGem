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
    [SerializeField]
    public float typingSpeed = 0.05f;
    private bool IsTypingMessage;
    Timer timer;
    private string Text
    {
        get { return textMeshProUGUI.text; }
        set
        {
            textMeshProUGUI.text = value;
        }
    }
    public void ShowMessage(string message)
    {
        StartCoroutine(DisplayMessage(message));
       
    }

    private IEnumerator DisplayMessage(string message)
    {
        Text = "";
        SetActive(true);
        IsTypingMessage = true;
        foreach (char letter in message.ToCharArray())
        {
            Text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        IsTypingMessage = false;
        yield return new WaitForSeconds(TimeToHide);
        SetActive(false);
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

    
}
