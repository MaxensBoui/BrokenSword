using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{

    public static Scoring s_instance;
    private int m_score;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (s_instance == null)
            s_instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoringSystem(int blockPoint/*, int multiplicator*/)
    {
        m_score += blockPoint /* multiplicator*/;
        m_scoreText.text = "Score :" + m_score;
    }
}
