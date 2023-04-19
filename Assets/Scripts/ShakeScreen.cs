using System;
using UnityEngine;
using Cinemachine;


public class ShakeScreen : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private float _shakeTimer;

    public static ShakeScreen Instance;
    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        Instance = this;
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intensity;
        _shakeTimer = time;
    }


    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = 0f;
            }
        }
    }
}
