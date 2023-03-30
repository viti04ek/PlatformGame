using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public Text Text;


    public void StartCharge()
    {
        Foreground.enabled = true;
        Text.enabled = true;
        Background.color = new Color(1, 1, 1, 0.2f);
    }


    public void StopCharge()
    {
        Foreground.enabled = false;
        Text.enabled = false;
        Background.color = new Color(1, 1, 1, 1);
    }


    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        Foreground.fillAmount = currentCharge / maxCharge;
        Text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
