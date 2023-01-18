using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPyh : MonoBehaviour
{
    public static WaterPyh instance;

    public float amplitude = 3f;
    public float lenght = 5f;
    public float speed = 2f;
    public float offset = 0f;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float _x)
    {
        return (float)(amplitude * Math.Sin(_x / lenght + offset));
    }
}
