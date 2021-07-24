using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseTrigger : MonoBehaviour
{
    public GameObject Hightlight;
    public UnityEvent MouseDown;
    public UnityEvent MouseUp;
    public UnityEvent MouseEnter;
    public UnityEvent MouseExit;

    private bool mouseDown = false;

    void OnMouseDown()
    {
        this.mouseDown = true;
        SetHighlight(false);
        this.MouseDown.Invoke();
    }

    void OnMouseUp()
    {
        this.mouseDown = false;
        this.MouseUp.Invoke();
    }

    void OnMouseEnter()
    {
        SetHighlight(true);
        this.MouseEnter.Invoke();
    }

    void OnMouseOver()
    {
        SetHighlight(true);
    }

    void OnMouseExit()
    {
        SetHighlight(false);
        this.MouseExit.Invoke();
    }

    private void SetHighlight(bool active)
    {
        if(this.Hightlight == null) return;
        if(!this.Hightlight.activeSelf && (Input.GetMouseButton(0) || Input.GetMouseButton(1))) return;
        this.Hightlight.SetActive(active);
    }
}
