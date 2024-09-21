using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private float m_blockDistance = 3.0f;
    [SerializeField] private GameObject m_counterParticle;
    [SerializeField] private GameObject m_shield;
    [SerializeField] private GameObject m_fallingShield;
    [SerializeField] private Transform m_shieldPosition;
    private Enemy m_enemy;
    // private List<GameObject> m_enemies = new List<GameObject>();
    [SerializeField] private bool m_canCounter;
    [SerializeField] private bool m_canTakeShield = false;

    [SerializeField] private Animator m_animator;
    [SerializeField] private GameObject m_counterCollider;

    private void Start()
    {
        m_canCounter = true;
        m_canTakeShield = false;
    }

    void Update()
    {
        //EnemyDetection();
    }
    //private void EnemyDetection()
    //{

    //foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
    //{
    //    if (TryGetComponent<Enemy>(out Enemy enemies))
    //    {
    //        m_enemy = GetComponent<Enemy>();
    //        Debug.Log(m_enemy.Counterable);

    //    }
    //    float enemiesFromPlayer = Vector3.Distance(transform.position, enemy.transform.position);
    //    if (enemiesFromPlayer < m_blockDistance && m_enemy.Counterable == true)
    //    {
    //        print("amamama");
    //        m_canCounter = true;
    //    }

    //}
    //
    public void OnBlockCounter(InputValue rea)
    {
        float value = rea.Get<float>();
        if (value > 0)
        {
            print("t");
            m_animator.Play("PlayerCounter");

            //    if (m_canCounter)
            //    {
            //        print("t");
            //        Instantiate(m_counterParticle, transform.position, Quaternion.identity);
            //        m_animator.Play("PlayerCounter");

            //    }
            //    else
            //    {
            //        m_shield.SetActive(true);
            //    }
            //}
            //    m_shield.SetActive(false);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawLine(transform.position, enemy.transform.position);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.gameObject.layer == 9 && m_canCounter)
        {
            Instantiate(m_counterParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject.transform.parent.gameObject);
            Debug.Log("enteredCollider");
            Debug.Log(other.gameObject.name);
            Debug.Log(other.transform.parent.name);
        }*/

        if (other.gameObject.CompareTag("Thunder"))
        {
            m_canTakeShield = true;
            m_canCounter = false;
            m_shield.SetActive(false);
            Instantiate(m_fallingShield, m_shieldPosition.position, Quaternion.identity);
            // StartCoroutine(ShieldRecovery());
        }

        if (other.gameObject.CompareTag("Shield") && m_canTakeShield)
        {
            StartCoroutine(ShieldRecovery());
            m_canCounter = true;
            m_canTakeShield = false;
            Destroy(other.gameObject);
        }    
    }

    IEnumerator ShieldRecovery()
    {
        yield return new WaitForSeconds(5.0f);
        m_shield.SetActive(true);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
    //        m_canCounter = true;
    //}

}