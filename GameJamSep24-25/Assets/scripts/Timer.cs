using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_currentTime = 30.0f;
    private float m_timeTextActive = 5.0f;
    private float m_minTime = 0.0f;
    private float m_resetCurrentTime = 30.0f;
    [SerializeField] private GameObject m_lightning;
    [SerializeField] private TextMeshProUGUI m_timerTextUI;
    [SerializeField] private string m_timerText;

    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = 30.0f;
        m_minTime = 0.0f;
        m_resetCurrentTime = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        m_timerText = m_currentTime.ToString("F0");
        m_timerTextUI.text = m_timerText;
        if(m_currentTime > m_timeTextActive)
        {
            m_timerTextUI.enabled = false;
        }
        else
        {
            m_timerTextUI.enabled = true;
        }
        if (m_currentTime <= m_minTime)
        {
            //code for spawn lightning
            Instantiate(m_lightning);
            //

            m_currentTime = m_resetCurrentTime;
        }
    }
}
