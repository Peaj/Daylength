using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SliderValueUI : MonoBehaviour
{
    public string Format;

    private Text Text;

    void OnEnable()
    {
        this.Text = this.GetComponent<Text>();
    }

    public void SetValue(float value)
    {
        if(this.Format != string.Empty) this.Text.text = string.Format(this.Format, value);
        else this.Text.text = value.ToString();
    }
}
