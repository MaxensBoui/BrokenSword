using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerLife : MonoBehaviour
{
   [SerializeField] private Scoring m_score;
  //  [SerializeField] private float m_scoreToLoseOnHit;
   [SerializeField] private bool m_immunity;
    private float m_immunityTimer;
   [SerializeField] private Collider m_playerCollider;

    void Start()
    {
       // m_score = Scoring.s_instance;
        m_immunity = false;

    }
    void Update()
    {
        ImmunityManager();
        //m_playerCollider.enabled = m_immunity;
    }

    private void ImmunityManager()
    {
        if (m_immunity)
            m_immunityTimer -= Time.deltaTime;


        if (m_immunityTimer <= 0)
            m_immunity = false;
    }

   /* private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 9)
        {
            Debug.Log("ded");
            if (!m_immunity)
            {
                m_score.ResetMultiplicator();
                m_score.LosePoint(m_scoreToLoseOnHit);
                m_immunity = true;
            }
        }
    }*/
}
