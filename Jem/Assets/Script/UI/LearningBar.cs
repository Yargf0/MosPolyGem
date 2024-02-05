using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningBar : ValueBar
{
    [SerializeField] 
    private TextMeshProUGUI LearningText;
    [SerializeField]
    LearningSystem LearningSystem;
    public override void SetValue(float value)
    {
        base.SetValue(value);
        Debug.Log("Value Setted ");
    }
    public void SetLearningText(int value)
    {
        LearningText.text = "Level: " + value;
    }
    public void SetLearningSystem(LearningSystem learningSystem)
    {
        this.LearningSystem = learningSystem;
        SetValue(learningSystem.GetLearningPoints());
        LearningSystem.ValueChanged.AddListener(SetValue);
        Debug.Log("AddedListener");
    }
}
