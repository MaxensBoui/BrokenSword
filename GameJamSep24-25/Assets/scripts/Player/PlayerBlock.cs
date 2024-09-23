using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private float m_blockDistance = 3.0f;
    public ParticleSystem m_counterParticle;
    [SerializeField] private GameObject m_shield;
    [SerializeField] private GameObject m_fallingShield;
    [SerializeField] private Transform m_shieldPosition;
    private Enemy m_enemy;
    [SerializeField] private bool m_canCounter;
    [SerializeField] private bool m_canTakeShield = false;
    [SerializeField] private bool m_thunderCollision = false;

    private Animator m_animator;
    [SerializeField] private Animator m_shieldAnimator;

    [SerializeField] private GameObject m_counterCollider;
    private void Start()
    {
        m_canCounter = true;
        m_canTakeShield = false;
        m_thunderCollision = false;
        m_animator = GetComponent<Animator>();
        // m_shieldAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
    }
 
    public void OnBlockCounter(InputValue rea)
    {
        float value = rea.Get<float>();
        if (value > 0)
        {

            print("t");
            m_shieldAnimator.SetTrigger("Attack");
            m_animator.SetTrigger("Attack");

            //    if (m_canCounter)
            //    {
            //        print("t");
            //        Instantiate(m_counterParticle, transform.position, Quaternion.identity);
            //        m_animator.Play("PlayerCounter");

            //    }
            //    else
            //    {
            //        m_shield.SetActive(true);
            //    }
            //}
            //    m_shield.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /* if (other.gameObject.layer == 9 && m_canCounter)
         {
             Instantiate(m_counterParticle, transform.position, Quaternion.identity);
             Destroy(other.gameObject.transform.parent.gameObject);
             Debug.Log("enteredCollider");
             Debug.Log(other.gameObject.name);
             Debug.Log(other.transform.parent.name);
         }*/

        if (other.gameObject.layer==10)
        {
            Debug.Log("thundaa");
//            m_canTakeShield = true;
            m_canCounter = false;
            m_shield.SetActive(false);
            if (m_thunderCollision == false)
            {
                Instantiate(m_fallingShield, m_shieldPosition.position, Quaternion.identity);
                m_thunderCollision = true;
            }
             StartCoroutine(ShieldRecovery());
        }

        if (other.gameObject.layer == 8 && m_canTakeShield == true)
        {
            m_canCounter = true;
            m_shield.SetActive(true);
            m_thunderCollision = false;
            m_canTakeShield = false;
            Destroy(other.gameObject);
        }
    }

    IEnumerator ShieldRecovery()
    {
        yield return new WaitForSeconds(5.0f);
        m_canTakeShield = true;
        // m_shield.SetActive(true);
    }



}