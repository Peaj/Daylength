using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    public float Radius = 1f;
    public int Resolution = 100;

    private Orbit Orbit;
    private LineRenderer LineRenderer;

    void Awake()
    {
        this.LineRenderer = this.GetComponent<LineRenderer>();
    }

    void OnValidate()
    {
        Refresh();
    }

    void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        this.LineRenderer = this.GetComponent<LineRenderer>();
        
        Vector3[] positions = new Vector3[this.Resolution];
        for(int i = 0; i < this.Resolution; ++i)
        {
            positions[i] = GetPoint(2f*Mathf.PI*i*(1f/this.Resolution));
        }
        this.LineRenderer.positionCount = this.Resolution;
        this.LineRenderer.SetPositions(positions);
    }

    public Vector3 GetPoint(float angle)
    {
        return new Vector3(Mathf.Cos(angle) * this.Radius, 0f, Mathf.Sin(angle) * this.Radius);
    }
}
