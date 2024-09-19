using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private float m_blockDistance = 3.0f;
    [SerializeField] private GameObject m_counterParticle;
    [SerializeField] private GameObject m_shield;
    private Enemy m_enemy;
    // private List<GameObject> m_enemies = new List<GameObject>();
    private bool m_canCounter;

    [SerializeField] private Animator m_animator;
    [SerializeField] private GameObject m_counterCollider;

    void Start()
    {

    }

    void Update()
    {

        print(m_canCounter);
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
            Instantiate(m_counterParticle, transform.position, Quaternion.identity);
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
        Destroy(other.gameObject.transform.parent.gameObject);
        Debug.Log("enteredCollider");
        Debug.Log(other.gameObject.name);
        Debug.Log(other.transform.parent.name);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
    //        m_canCounter = true;
    //}
}
