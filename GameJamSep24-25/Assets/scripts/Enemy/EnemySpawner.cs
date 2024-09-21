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
            Vector3 spawnCircle = new Vector3(m_circleSize* Random.insideUnitCircle.x , 0, m_circleSize * Random.insideUnitCircle.y);
            Instantiate(m_enemyPrefab,  spawnCircle, Quaternion.identity);
            //Debug.Log("SpawningEnemy");
            m_timer = 0;
        }
    }
}
