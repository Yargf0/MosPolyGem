using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public  class ValueSystem 
{
    [SerializeField] public ValueEvent ValueChanged = new ValueEvent();
    private int _value;
    private int _valuemax;
    public void Setup(int value)
    {
        _value = _valuemax = value;
        SayChanged();
    }
    public void AddValue(int value)
    {
        _value=Mathf.Clamp(_value + value, 0, _valuemax);
        SayChanged();
    } 
    public void RemoveValue(int value)
    {
        _value=Mathf.Clamp(_value - value, 0, _valuemax);
        SayChanged();
    }
    private void SayChanged()
    {
        ValueChanged.Invoke((float)_value / _valuemax);
    }
    public int GetValue()
    {
        return _value;
    }
}
[System.Serializable]
public class ValueEvent : UnityEvent<float> { }
