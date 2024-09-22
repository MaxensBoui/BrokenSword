using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    [SerializeField] private GameObject m_PanelUI;
    // Start is called before the first frame update
    void Start()
    {
        m_PanelUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
