using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_charaControl;
    [SerializeField] private float m_movementSpeed = 10;
    private PlayerInput m_playerInput;
    private InputActionMap m_actionMap;
    private Vector3 m_movement;
    private Vector3 m_keyboardMovement;
    private float m_yValue;
    private float m_xValue;

    [SerializeField] private ParticleSystem m_walkParticle;

    //My attempt at rotating
    ////[SerializeField] private float m_smoothDampSpeed = 0.05f;
    ////private float m_currentVelocity;
    void Start()
    {
        m_charaControl = GetComponent<CharacterController>();
        m_playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        m_keyboardMovement = new Vector3(m_xValue, 0, m_yValue); 

        m_charaControl.Move(m_movement * Time.deltaTime * m_movementSpeed);

       // m_keyboardMovement = new Vector3(m_xValue, 0, m_yValue);
     //   m_charaControl.Move(m_keyboardMovement * Time.deltaTime * m_movementSpeed);
    }
    public void OnMovement(InputValue readValue)
    {
        Vector2 move = readValue.Get<Vector2>();
        Vector3 cam = Camera.main.transform.forward;
        cam.y = 0;
        cam.Normalize();
        Vector3 right = Vector3.Cross(Vector3.up, cam);

        move = move.x * new Vector2(right.x, right.z) + move.y * new Vector2(cam.x, cam.z);

           Vector3 movement = new Vector3(move.x, 0, move.y);
       // transform.Translate(movement * Time.deltaTime * m_movementSpeed);

        m_movement = movement;

        if (movement == Vector3.zero)
            return;

        transform.rotation = Quaternion.LookRotation(movement);

        //my attempt at rotating
        ////var targetAngle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
        ////var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_currentVelocity, m_smoothDampSpeed);
        ////transform.rotation = Quaternion.Euler(0, angle, 0);


    }

    #region Keyboard
    public void OnUpMovement(InputValue readValue)
    {
        m_yValue = readValue.Get<float>();
       
    }
    public void OnSideMovement(InputValue readValue)
    {
        m_xValue = readValue.Get<float>();
        
    }
    #endregion
}
