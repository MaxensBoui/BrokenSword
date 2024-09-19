using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject m_target;
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private float m_deathTimer = 2f; //Timer at which the enemy disappears, must be after the VFX and Animation are done (value is a placeholder)


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
        Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);

        //Make attack at random timing

        //When countered : 
        //m_state = EEnemyStateMach.Dead
    }

    private void Die()
    {
        //insert death VFX
        //insert death animation
        Destroy(gameObject, m_deathTimer);
    }
}
