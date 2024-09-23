using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float m_shakeDuration = .5f;
    public static CameraShake s_instance;

    private bool m_isShaking = false;
    [SerializeField] private float m_trauma;

    void Start()
    {
        if (s_instance == null)
            s_instance = this;
    }

    public void Shake(float shakeForce)
    {
        if (m_isShaking)
        {
            StopAllCoroutines();
        }
        StartCoroutine(Shaker(shakeForce));
    }


    private IEnumerator Shaker(float shakeForce)
    {
        m_isShaking = true;
        float timer = 0;
        m_trauma += shakeForce;
        while (timer < m_shakeDuration)
        {
            timer += Time.unscaledDeltaTime;
            Vector3 newPosition = transform.position + Random.insideUnitSphere * m_trauma;
            transform.position = newPosition;
            shakeForce = Mathf.Pow((1 - (timer / m_shakeDuration)), 2);
            yield return null;
        }
        m_trauma = 0;
        m_isShaking = false;

    }
}
