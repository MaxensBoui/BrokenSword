using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float m_spawnTick = 3f;
    [SerializeField] private float m_circleSize = 10f;
    private float m_timer;

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer >= m_spawnTick)
        {
            Instantiate(m_enemyPrefab, Random.insideUnitSphere * m_circleSize, Quaternion.identity);
            //Debug.Log("SpawningEnemy");
            m_timer = 0;
        }
    }
}
