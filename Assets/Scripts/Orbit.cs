using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Orbit : MonoBehaviour
{
    public float RadiusX = 1f;
    public float RadiusY = 1f;
    public float Angle;

    void Update()
    {
        this.transform.position = GetPoint(this.Angle);
    }

    public Vector3 GetPoint(float angle)
    {
        return new Vector3(Mathf.Cos(angle) * this.RadiusX, 0f, Mathf.Sin(angle) * this.RadiusY);
    }
}
