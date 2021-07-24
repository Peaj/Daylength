using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleHelper : MonoBehaviour
{
    public Graphic InverseGraphic;

    private Toggle toggle;

    void OnEnable()
    {
        this.toggle = this.GetComponent<Toggle>();
        this.toggle.onValueChanged.AddListener(OnValueChanged);

        if(this.InverseGraphic != null) this.InverseGraphic.CrossFadeAlpha(!this.toggle.isOn ? 1f : 0f, 0f, true);
    }

    void OnValueChanged(bool value)
    {
        if(this.InverseGraphic != null)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                this.InverseGraphic.canvasRenderer.SetAlpha(!value ? 1f : 0f);
            else
#endif
            this.InverseGraphic.CrossFadeAlpha(!value ? 1f : 0f, 0.1f, true);
        }
    }

    void OnDisable()
    {
        this.toggle.onValueChanged.RemoveListener(OnValueChanged);
    }
}
