using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{

    [SerializeField] private GameObject m_endScreen;
    [SerializeField] private TextMeshProUGUI m_endScore;
    private Scoring m_score;
    public static EndScreen s_instance;
    private int m_lightningCount;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        m_score = GetComponent<Scoring>();
        m_lightningCount = 0;
        m_endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_lightningCount >= 4)
        {
            m_endScreen.SetActive(true);
            m_endScore.text = "Final score " + m_score.Score;
            Time.timeScale = 0.0f;

        }

    }

    public void LightningCount()
    {
        m_lightningCount++;
    }
}
