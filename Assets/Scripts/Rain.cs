using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _ps;
    private bool _isRain = false;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        switch (_isRain)
        {
            case true when dirLight.intensity > 0.25f:
                LightIntensity(-1);
                break;
            case false when dirLight.intensity < 0.5f:
                LightIntensity(1);
                break;
        }
    }

    private void LightIntensity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    private IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 15f));

            if (_isRain)
                _ps.Stop();
            else
                _ps.Play();


            _isRain = !_isRain;
        }
    }
}