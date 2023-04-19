using System;
using UnityEngine;
using Cinemachine;


public class ShakeScreen : MonoBehaviour
{
    private CinemachineVirtualCamera camera;
    private float shakeTimer;

    public static ShakeScreen Instance;
    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        Instance = this;
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }


    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = 0f;
            }
        }
    }
}
