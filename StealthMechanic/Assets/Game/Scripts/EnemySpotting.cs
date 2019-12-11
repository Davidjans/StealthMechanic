using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpotting : MonoBehaviour
{
    [SerializeField] private EnemyInfo m_EnemyInfo;
    [SerializeField] private PlayerInfo m_PlayerInfo;
    [SerializeField] private float m_ChaseRange;
    [SerializeField] private Animator m_Animator;
    public EnemyState m_EnemyState;

    private Ray m_Sight;
    private bool m_AggresiveToPlayer;

    // Update is called once per frame
    void Update()
    {
        m_Sight.origin = new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z);
        m_Sight.direction = transform.forward;
        RaycastHit rayHit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(m_Sight, out rayHit, m_ChaseRange))
        {
            Debug.DrawLine(m_Sight.origin, rayHit.point,Color.red);

            if (rayHit.collider.tag == "Player")
            {
                Debug.Log("HitPlayer");
                if (m_PlayerInfo.m_CostumeState != m_EnemyInfo.m_CostumeState)
                {
                    m_AggresiveToPlayer = true;
                    m_EnemyState = EnemyState.Aggresive;
                    m_Animator.SetInteger("EnemyState", 2);
                }
                else
                {
                    m_AggresiveToPlayer = false;
                    m_EnemyState = EnemyState.Friendly;
                    m_Animator.SetInteger("EnemyState", 0 );
                }
            }
        }
        Debug.Log(m_AggresiveToPlayer);
    }
}

public enum EnemyState
{
    Friendly,
    Neutral,
    Aggresive
}
