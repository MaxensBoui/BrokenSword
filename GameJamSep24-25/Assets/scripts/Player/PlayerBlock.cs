using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private float m_blockDistance = 3.0f;
    private Enemy m_enemy;
   // private List<GameObject> m_enemies = new List<GameObject>();
    private bool m_canCounter;
    void Start()
    {

    }

    void Update()
    {

        print(m_canCounter);
        EnemyDetection();
    }
    private void EnemyDetection()
    {

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            m_enemy = GetComponent<Enemy>();
            print(m_enemy.Counterable);
            float enemiesFromPlayer = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemiesFromPlayer < m_blockDistance && m_enemy.Counterable == true)
                m_canCounter = true;
        }
    }
    public void OnBlockCounter()
    {
        if(m_canCounter)
            print("t");
    }

    private void OnDrawGizmos()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, enemy.transform.position);
        }
    }
}
