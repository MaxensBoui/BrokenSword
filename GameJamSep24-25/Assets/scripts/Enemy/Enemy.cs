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
    private PlayerBlock m_player;
    [SerializeField] private int m_pointObtained;
    [SerializeField] private int m_pointLost;
    [SerializeField] private float m_multiplicatorBonus;
    [SerializeField] private GameObject m_destroyVisualize;
    private Scoring m_score;
    [SerializeField] private float m_spawnTimer = 2f;
    private float m_timer;
    private Animator m_animator;
    [SerializeField] private Animator m_attackAnimator;
    [SerializeField] private ParticleSystem m_attackAnticipationParticle;
    [SerializeField] private Transform m_handJoint;

    private float m_atkTimer;
    [SerializeField] private float m_atkRate = 2f;

    private bool m_counterable = false;
    public bool Counterable => m_counterable;

    //[SerializeField] private GameObject m_collider;

    private EEnemyStateMach m_state;

    public enum EEnemyStateMach
    {
        Spawning,
        Attacking,
        Dead
    }

    private void Awake()
    {
        m_player = FindAnyObjectByType<PlayerBlock>();
    }
    void Start()
    {
        if (m_target == null) { m_target = GameObject.FindWithTag("Player"); }
        m_state = EEnemyStateMach.Spawning;
        m_currentSpeed = m_speed;
        //m_collider.SetActive(false);
        m_score = Scoring.s_instance;
        m_animator = GetComponent<Animator>();
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

        //Debug.Log(m_collider.activeSelf);
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
        m_animator.SetBool("Running", true);
        if (distance > m_offsetDist)
        {
            m_currentSpeed = m_speed;
        }
        else
        {
            m_currentSpeed = 0;
            m_animator.SetBool("Running", false);

        }

        m_atkTimer += Time.deltaTime;

        //placeholder script for attack pattern
        if (m_atkTimer >= m_atkRate)
        {
            //attackanim
            //insert attack anim and vfx
            m_animator.SetBool("Running", false);

            m_animator.SetTrigger("Attack");
         //   m_attackAnimator.SetTrigger("Attack");
            m_atkTimer = 0f;
        }

    }

    private void Die()
    {
        //insert death VFX
        //insert death animation
        m_anim.SetTrigger("Die");
        //Destroy(gameObject, m_deathTimer);
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
    }

    public void PlayParticle()
    {
        m_attackAnticipationParticle.Play();
    }
    public void CounterableTrue()
    {
        m_counterable = true;

        //Instantiate(m_attackAnticipationParticle, m_handJoint.position, Quaternion.identity);
    }
    public void CounterableFalse()
    {
        m_counterable = false;
    }
    private void OnDestroy()
    {
        m_score.ScoringSystem(m_pointObtained);
        m_score.Multiplicator(m_multiplicatorBonus);
        m_score.ResetMultiplicationTimer();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            m_score.ResetMultiplicator();
            m_score.LosePoint(m_pointLost);
        }
        if (other.gameObject.layer == 8 && m_counterable)
        {
            m_player.m_counterParticle.Play();
            Die();
        }
    }
}
