using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TeleportPlace : MonoBehaviour
{
    [SerializeField] private EnemySpotting m_EnemySpotting;
    [SerializeField] private TeleportArea m_TeleportArea;
    // Start is called before the first frame update
    void Start()
    {
        if(m_TeleportArea == null)
        {
            m_TeleportArea = GetComponent<TeleportArea>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EnemySpotting.m_EnemyState != EnemyState.Friendly)
        {
            m_TeleportArea.locked = true;
        }
        else
        {
            m_TeleportArea.locked = false;
        }
    }
}
