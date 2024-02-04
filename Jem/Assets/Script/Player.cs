using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //не здесь, а в ui контроллере??
    [SerializeField]
    LearningBar LearningBar;

    LearningSystem LearningSystem;
    void Start()
    {
        LearningSystem=GetComponent<LearningSystem>();
        LearningBar.SetLearningSystem(LearningSystem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
