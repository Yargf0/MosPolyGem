using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    private Objectthatgivelerning PreviousObjectthatgivelerning;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray= mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,100) ) 
        {
            Objectthatgivelerning Objectthatgivelerning = hit.collider.GetComponent<Objectthatgivelerning>();
            if(Objectthatgivelerning != null )
            {
                Outline outline  = Objectthatgivelerning.GetComponent<Outline>();
                outline.OutlineWidth = 5;
                PreviousObjectthatgivelerning=Objectthatgivelerning;
            }
        }
        else 
        {
            if (PreviousObjectthatgivelerning != null)
            {
                Outline outline = PreviousObjectthatgivelerning.GetComponent<Outline>();
                outline.OutlineWidth = 0;
                PreviousObjectthatgivelerning = null;
            }
        }
    }
}
