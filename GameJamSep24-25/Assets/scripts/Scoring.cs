using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{

    public static Scoring s_instance;
    private float m_score;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_multiplicatorText;
    private float m_multiplicator = 1.0f;
    private float m_multiplicatorTimer;
    [SerializeField] private float m_multiplicatorTime;

    void Start()
    {
        if (s_instance == null)
            s_instance = this;

        m_scoreText.text = "Score :" + 0;
        m_multiplicatorText.text = "x" + m_multiplicator;
        m_multiplicatorTimer = m_multiplicatorTime;

    }
    private void Update()
    {
        if(m_multiplicatorTimer>0)
            m_multiplicatorTimer -= Time.deltaTime;
        if (m_multiplicatorTimer <= 0)
            m_multiplicator = 1;
        m_multiplicatorText.text = "x" + m_multiplicator;
    }

    public void ResetMultiplicator()
    {
        m_multiplicator = 1.0f;
    }
    public void ResetMultiplicationTimer()
    {
        m_multiplicatorTimer = m_multiplicatorTime;
    }
    public void Multiplicator(float multiplicator)
    {
        m_multiplicatorTimer = Mathf.Clamp(m_multiplicatorTimer, 0, m_multiplicatorTime);
        m_multiplicator += multiplicator;
    }
    public void ScoringSystem(float blockPoint)
    {
        m_score += blockPoint * m_multiplicator;
        m_scoreText.text = "Score :" + (int)m_score;
    }
    public void LosePoint(float pointToLose)
    {
        m_score -= pointToLose;
        m_score = Mathf.Clamp(m_score, 0, Mathf.Infinity);
        m_scoreText.text = "Score :" + (int)m_score;
    }
}
