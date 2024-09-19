using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private Vector3 m_positionOffset;
    [SerializeField] private float m_smoothTime = 0.2f;
    private Vector3 m_cameraTransform;
    private Vector3 m_velocity = Vector3.zero;
  
    void Update()
    {
        m_cameraTransform = m_positionOffset + m_player.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_cameraTransform,ref m_velocity, m_smoothTime);
    }
}
