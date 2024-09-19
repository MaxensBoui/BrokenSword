using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject m_target;
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private float m_currentSpeed;
    [SerializeField] private float m_deathTimer = 2f; //Timer at which the enemy disappears, must be after the VFX and Animation are done (value is a placeholder)
    [SerializeField] private float m_offsetDist = 1.5f; //distance at which the enemy will stop going towards the player
    [SerializeField] private Animator m_anim;

    [SerializeField] private float m_spawnTimer = 2f;
    private float m_timer;

    private float m_atkTimer;
    [SerializeField] private float m_atkRate = 2f;

    private EEnemyStateMach m_state;

    public enum EEnemyStateMach
    {
        Spawning,
        Attacking,
        Dead
    }

    void Start()
    {
        if (m_target == null) {m_target = GameObject.FindWithTag("Player");}
        m_state = EEnemyStateMach.Spawning;
        m_currentSpeed = m_speed;
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


        //temporary timer
        m_timer += Time.deltaTime;
    }

    private void Spawn()
    {
        //Insert VFX of spawning
        //when VFX Done :
        //m_state = EEnemyStateMach.Attacking

        if (m_timer >= m_spawnTimer) 
        {
            m_state = EEnemyStateMach.Attacking;
        }

    }

    private void Attack()
    {
        transform.LookAt(m_target.transform.position);

        //Make attack at random timing

        //When countered : 
        //m_state = EEnemyStateMach.Dead
        transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_currentSpeed * Time.deltaTime);


        float distance = Mathf.Abs(Vector3.Distance(transform.position, m_target.transform.position));

        if (distance > m_offsetDist)
        {
            m_currentSpeed = m_speed;
        }
        else
        {
            m_currentSpeed = 0;
        }

        m_atkTimer += Time.deltaTime;

        //placeholder script for attack pattern
        if (m_atkTimer >= m_atkRate)
        {
            //attackanim
            //insert attack anim and vfx


            m_anim.Play("EnemyAttackAnim");
            m_atkTimer = 0f;
        }

    }

    private void Die()
    {
        //insert death VFX
        //insert death animation
        Destroy(gameObject, m_deathTimer);
    }
}
