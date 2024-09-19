using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_currentTime = 0.0f;
    private float m_maxTime = 30.0f;
    private float m_resetCurrentTime = 0.0f;
    [SerializeField] private GameObject m_lightning;
    [SerializeField] private TextMeshProUGUI m_timerTextUI;
    [SerializeField] private string m_timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;
        m_timerText = m_currentTime.ToString("F2");
        m_timerTextUI.text = m_timerText; 
        if (m_currentTime >= m_maxTime)
        {
            //code for spawn lightning
            Instantiate(m_lightning);
            //

            m_currentTime = m_resetCurrentTime;
        }
    }
}
