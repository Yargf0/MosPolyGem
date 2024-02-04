using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningSystem : ValueSystem
{
    public void AddLearningPoints(int points)
    {
        base.AddValue(points);
        //playSound("����������");
    }
    public void RemoveLearningPoints(int points)
    {
        base.RemoveValue(points);
        //playSound("���������");
    }
    public void SetLearningPoints(int points)
    {
        base.Setup(points);
    }


}
