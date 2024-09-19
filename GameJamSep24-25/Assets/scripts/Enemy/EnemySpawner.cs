using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float m_spawnTick = 3f;
    [SerializeField] private float m_circleSize = 10f;
    private int timer;

    void Update()
    {
        timer += Mathf.RoundToInt(Time.deltaTime);

        if (timer % m_spawnTick == 1)
        {
            Instantiate(m_enemyPrefab, Random.insideUnitSphere * m_circleSize, Quaternion.identity);
            Debug.Log("SpawningEnemy");
        }

        Debug.Log(timer % m_spawnTick);
    }
}
