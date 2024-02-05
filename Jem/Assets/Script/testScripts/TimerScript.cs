using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float MaxTime;
    private float currentTime;
    public TMP_Text timerShow;
    public bool Tick;

    /// <summary>
    /// простой таймер. 
    /// 
    /// переменная Тик служит для того, чтобы можно было какие-то 
    /// действия из других скриптов привязать к истечению этого времени, 
    /// к примеру, конец раунда. По умолчанию переменная false, 
    /// но после достижения MaxTime она "тикает" на true. 
    /// </summary>
    void Start()
    {
        currentTime = MaxTime;
    }

    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;

        if (currentTime<=0)
        {
            Tick=true;
            currentTime = MaxTime;
        }

        int minutes = (int)(currentTime / 60);
        int seconds = (int)(currentTime % 60);
        if (seconds<10)
            timerShow.text = $"{minutes}:{"0" + seconds}";
        else if (seconds>10)
            timerShow.text = $"{minutes}:{ seconds}";
    }
}
