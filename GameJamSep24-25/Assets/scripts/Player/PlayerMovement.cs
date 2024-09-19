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
        transform.Translate(m_keyboardMovement * Time.deltaTime * m_movementSpeed);

        //m_charaControl.Move(m_movement * Time.deltaTime * m_movementSpeed);

    }
    public void OnMovement(InputValue readValue)
    {
        Debug.Log("k");
        Vector2 move = readValue.Get<Vector2>();
        print("move");
            m_movement = new Vector3(move.x, 0, move.y);
        transform.Translate(m_movement * Time.deltaTime * m_movementSpeed);

        //  transform.Rotate(move);

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

  /*  public void OnSwitch(InputValue readValue)
    {
        Vector2 notZero = readValue.Get<Vector2>();
        if(notZero != Vector2.zero)
            m_actionMap.
    }*/
    #endregion
}
