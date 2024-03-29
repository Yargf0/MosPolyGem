using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningBar : ValueBar
{
    [SerializeField] 
    private TextMeshProUGUI LearningText;
    private void Start()
    {
        LearningSystem.i.ValueChanged.AddListener(SetValue);
    }
    public override void SetValue(float value)
    {
        base.SetValue(value);
        Debug.Log("Value Setted ");
    }
    public void SetLearningText(int value)
    {
        LearningText.text = "Level: " + value;
    }
}
