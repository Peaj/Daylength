using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookDrag : MonoBehaviour
{
    public Vector2 Speed;

    private CinemachineFreeLook Camera;

    void Awake()
    {
        this.Camera = this.GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        
        if(Input.GetMouseButton(1))
        {
            this.Camera.m_XAxis.m_InputAxisValue = Input.GetAxis("Mouse X") * Speed.x;
            this.Camera.m_YAxis.m_InputAxisValue = Input.GetAxis("Mouse Y") * Speed.y;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            this.Camera.m_XAxis.m_InputAxisValue = 0f;
            this.Camera.m_YAxis.m_InputAxisValue = 0f;
        }
    }
}
