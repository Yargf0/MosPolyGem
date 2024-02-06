using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    float TimeToHide = 5.0f;
    [SerializeField]
    public float typingSpeed = 0.05f;
    private bool IsTypingMessage;
    private bool active;
    //Timer timer;
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
        gameObject.SetActive(true);
        IsTypingMessage = true;
        foreach (char letter in message.ToCharArray())
        {
            Text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        IsTypingMessage = false;
        yield return new WaitForSeconds(TimeToHide);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
