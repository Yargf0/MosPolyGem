using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    [SerializeField] private Image allEnding;
    [SerializeField] private Image loxEnding;
    [SerializeField] private Image goodEnding;
    public void End(bool i)
    {
        if (i)
        {
            ShowImage(goodEnding);
        }
        else
        {
            ShowImage(loxEnding);
        }
    }
    private void ShowImage(Image i)
    {

    }
}
