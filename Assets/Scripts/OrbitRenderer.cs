using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbit), typeof(LineRenderer))]
public class OrbitRenderer : MonoBehaviour
{
    public int Resolution = 100;

    private Orbit Orbit;
    private LineRenderer LineRenderer;

    void Awake()
    {
        this.Orbit = this.GetComponent<Orbit>();
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
        this.Orbit = this.GetComponent<Orbit>();
        this.LineRenderer = this.GetComponent<LineRenderer>();
        
        Vector3[] positions = new Vector3[this.Resolution];
        for(int i = 0; i < this.Resolution; ++i)
        {
            positions[i] = this.Orbit.GetPoint(2f*Mathf.PI*i*(1f/this.Resolution));
        }
        this.LineRenderer.positionCount = this.Resolution;
        this.LineRenderer.SetPositions(positions);
    }
}
