using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //�� �����, � � ui �����������??
    [SerializeField]
    LearningBar LearningBar;
    void Start()
    {
        LearningBar.SetLearningSystem(LearningSystem._i);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
