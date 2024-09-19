using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float s_half = 0.49999999999f;
    [SerializeField] private GameObject m_player;
    private Vector3 m_positionOffset;
    [SerializeField] private float m_smoothTime = 0.2f;
    private Vector3 m_targetTransform;
    private Vector3 m_velocity = Vector3.zero;
    [SerializeField] private float m_yaw;
    [SerializeField] private float m_pitch;
    [SerializeField] private float m_dolly;
    private void Start()
    {
        m_positionOffset = transform.position;
    }
    void LateUpdate()
    {
        m_targetTransform = m_positionOffset + m_player.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_targetTransform,ref m_velocity, m_smoothTime);
    }

    private void OnValidate()
    {

        m_pitch = Mathf.Clamp(m_pitch, -Mathf.PI * s_half, Mathf.PI * s_half);
        Vector3 orbit = new Vector3(Mathf.Cos(m_yaw)*Mathf.Cos(m_pitch), Mathf.Sin(m_pitch), Mathf.Sin(m_yaw)*Mathf.Cos(m_pitch));
        Vector3 position = m_player.transform.position + orbit * m_dolly;

        transform.position = position;
        transform.LookAt(m_player.transform);
    }
}
