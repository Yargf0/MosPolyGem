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
    /// ������� ������. 
    /// 
    /// ���������� ��� ������ ��� ����, ����� ����� ���� �����-�� 
    /// �������� �� ������ �������� ��������� � ��������� ����� �������, 
    /// � �������, ����� ������. �� ��������� ���������� false, 
    /// �� ����� ���������� MaxTime ��� "������" �� true. 
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
