using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class SolarSystem : MonoBehaviour
{
    public float Day = 0f;
    public float Speed = 1f;
    public bool Playing = false;

    public Slider Slider;

    public Orbit EarthOrbit;
    public Rotate EarthRotation;

    void Update()
    {
        if(Application.isPlaying && this.Playing)
        {
            this.Day = Mathf.Repeat(this.Day + this.Speed * Time.deltaTime, 365f);
            if(this.Slider != null) this.Slider.value = this.Day;
        }

        if(!this.EarthOrbit || ! this.EarthRotation) return;

        float radians = (this.Day+10f)/365f * Mathf.PI * 2;
        this.EarthOrbit.Angle = radians;
        this.EarthRotation.Rotation = -(this.Day+10f) * 360f;
    }

    public void TogglePlay()
    {
        this.Playing = !this.Playing;
    }

    public void Play()
    {
        this.Playing = true;
    }

    public void Pause()
    {
        this.Playing = false;
    }

    public void Stop()
    {
        this.Playing = false;
        this.Day = 0f;
    }

    public void SetDay(float day)
    {
        this.Day = day;
        if(this.Slider != null) this.Slider.value = this.Day;
    }

    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }
}
