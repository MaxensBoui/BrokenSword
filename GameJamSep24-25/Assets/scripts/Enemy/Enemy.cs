using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private float m_currentSpeed = m_speed;
    [SerializeField] private float m_deathTimer = 2f; //Timer at which the enemy disappears, must be after the VFX and Animation are done (value is a placeholder)
    [SerializeField] private float m_offsetDist = 1f; //distance at which the enemy will stop going towards the player

    private EEnemyStateMach m_state;

    public enum EEnemyStateMach
    {
        Spawning,
        Attacking,
        Dead
    }

    void Start()
    {
        m_target = GameObject.FindWithTag("Player");
        m_state = EEnemyStateMach.Spawning;
    }

    void Update()
    {
        {
            switch (m_state)
            {
                case EEnemyStateMach.Spawning:
                    Spawn();
                    break;
                case EEnemyStateMach.Attacking:
                    Attack();
                    break;
                case EEnemyStateMach.Dead:
                    Die();
                    break;
            }
        }
    }

    private void Spawn()
    {
        //Insert VFX of spawning
        //when VFX Done :
        //m_state = EEnemyStateMach.Attacking
    }

    private void Attack()
    {
        transform.LookAt(m_target.transform.position);
       
        //Make attack at random timing

        //When countered : 
        //m_state = EEnemyStateMach.Dead

        
        float distance = Mathf.Abs(Vector3.Distance(transform.position, m_target.transform.position));

        if (distance > m_offsetDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);
        }
        else
        {
            m_currentSpeed = 0;
        }

        //placeholder script for attack pattern
        //if (m_timer >= m_attackRate)
        //{
        //      insert attack anim and vfx
        //    m_timer = 0f;
        //}

    }

    private void Die()
    {
        //insert death VFX
        //insert death animation
        Destroy(gameObject, m_deathTimer);
    }
}
