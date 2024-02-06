using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Outline))]
public class Objectthatgivelerning : MonoBehaviour
{
    [SerializeField]
    int LearningPoints;
    Outline outline;
    private void OnEnable()
    {
        outline = GetComponent<Outline>();

        outline.OutlineWidth = 3;
    }
    public void OnHoverEnter()
    {
        outline.OutlineWidth = 2;
    }
    public void OnHoverExit()
    {
        outline.OutlineWidth = 0;
    }
}
