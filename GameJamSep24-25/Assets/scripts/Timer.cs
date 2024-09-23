using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int s_yOffset = 20;
    private float m_currentTime = 30.0f;
    private float m_timeTextActive = 5.0f;
    private float m_minTime = 0.0f;
    private float m_resetCurrentTime = 10.0f;
    [SerializeField] private GameObject m_lightning;
    [SerializeField] private TextMeshProUGUI m_timerTextUI;
    [SerializeField] private string m_timerText;
    private CameraShake m_cam;
    [SerializeField] private float m_shakeForce;
    [SerializeField] private EndScreen m_lightningCount;



    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = 10.0f;
        m_minTime = 0.0f;
        m_resetCurrentTime = 10.0f;
        m_cam = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        m_timerText = m_currentTime.ToString("F0");

        m_timerTextUI.text = m_timerText;

        if (m_currentTime > m_timeTextActive)
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
            Vector3 instPos = new Vector3(transform.position.x, s_yOffset, transform.position.z);
            Instantiate(m_lightning, instPos, Quaternion.identity);
            m_cam.Shake(m_shakeForce);
            m_lightningCount.LightningCount();

            m_currentTime = m_resetCurrentTime;
        }
    }
}
