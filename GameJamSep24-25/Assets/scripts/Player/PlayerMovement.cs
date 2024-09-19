using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_charaControl;
    [SerializeField] private float m_movementSpeed = 10;
    private Vector3 m_movement;
    void Start()
    {
        m_charaControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Translate(m_movement * Time.deltaTime * m_movementSpeed);
        //m_charaControl.Move(m_movement * Time.deltaTime * m_movementSpeed);

    }
    public void OnMovement(InputValue readValue)
    {
        Vector2 move = readValue.Get<Vector2>();
        m_movement = new Vector3(move.x, 0, move.y);

        transform.Rotate(move);
    }
 
}
