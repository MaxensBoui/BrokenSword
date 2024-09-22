using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private float m_lightningTiming;
    private float m_lightningMaxTiming = 1.0f;
    private float m_lightningMinTiming = 0.0f;
    void Awake()
    {
        m_lightningTiming = m_lightningMaxTiming;
    }

    void Update()
    {
        m_lightningTiming -= Time.deltaTime;
        if (m_lightningTiming <= m_lightningMinTiming)
        {
            //gameObject.SetActive(false);
            //m_lightningTiming = m_lightningMaxTiming;
            Destroy(this.gameObject);
        }
    }
}
