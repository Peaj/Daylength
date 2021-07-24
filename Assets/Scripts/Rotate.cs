using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Rotate : MonoBehaviour
{
    public float Rotation = 0f;

    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(0f,this.Rotation,0f);
    }
}
