using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LearningSystem : ValueSystem
{
    public static LearningSystem _i { get; private set; }
    [SerializeField]
    int maxpoints=10;
    UnityEvent Win;
    public void Start()
    {
        _i = this;
        _i.Setup(maxpoints);
    }
    public void AddLearningPoints(int points)
    {
        base.AddValue(points);
        //playSound("МыПоумнели");
        if (GetLearningPoints()== maxpoints)
        {
            Win?.Invoke();
        }
    }
    public void RemoveLearningPoints(int points)
    {
        base.RemoveValue(points);
        //playSound("МыОтупели");
    }
    public void SetLearningPoints(int points)
    {
        base.Set(points);
    }
    public int GetLearningPoints()
    {
       return base.GetValue();
    }
    public void ResetPoints()
    {
        base.Set(0);
    }


}
