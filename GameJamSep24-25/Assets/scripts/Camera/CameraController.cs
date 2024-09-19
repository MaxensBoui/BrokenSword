using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private Vector3 m_positionOffset;
  
    void Update()
    {
        transform.position = m_positionOffset + m_player.transform.position;
    }
}
