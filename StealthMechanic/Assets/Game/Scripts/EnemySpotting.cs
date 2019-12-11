using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpotting : MonoBehaviour
{
    [SerializeField] private EnemyInfo m_EnemyInfo;
    [SerializeField] private PlayerInfo m_PlayerInfo;
    [SerializeField] private float m_ChaseRange;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private float m_OriginalGuaranteedAngerTimer = 20;
    [SerializeField] private TextMeshProUGUI m_TimerText;
    public EnemyState m_EnemyState;

    private float m_CurrentGuaranteedAngerTimer;
    private Ray m_Sight;
    private bool m_AggresiveToPlayer;
    private bool m_SeenLastFrame;
    private CostumeState m_LastFrameCostume;
    // Update is called once per frame
    void Update()
    {
        m_Sight.origin = new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z);
        m_Sight.direction = m_PlayerInfo.transform.position - transform.position;
        RaycastHit rayHit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(m_Sight, out rayHit, m_ChaseRange))
        {
            Debug.DrawLine(m_Sight.origin, rayHit.point,Color.red);

            if (rayHit.collider.tag == "Player")
            {
                m_SeenLastFrame = true;
                Debug.Log("HitPlayer");
                if(m_CurrentGuaranteedAngerTimer > 0)
                {
                    m_AggresiveToPlayer = true;
                    m_EnemyState = EnemyState.Aggresive;
                    m_Animator.SetInteger("EnemyState", 2);
                }
                else
                {
                    if (m_SeenLastFrame == true && m_LastFrameCostume != m_PlayerInfo.m_CostumeState)
                    {
                        m_CurrentGuaranteedAngerTimer = m_OriginalGuaranteedAngerTimer;
                    }
                    if (m_PlayerInfo.m_CostumeState != m_EnemyInfo.m_CostumeState && m_CurrentGuaranteedAngerTimer > 0)
                    {
                        m_AggresiveToPlayer = true;
                        m_EnemyState = EnemyState.Aggresive;
                        m_Animator.SetInteger("EnemyState", 2);
                    }
                    else
                    {
                        m_AggresiveToPlayer = false;
                        m_EnemyState = EnemyState.Friendly;
                        m_Animator.SetInteger("EnemyState", 0);
                    }
                }
            }
            else
            {
                m_SeenLastFrame = false;
            }
        }
        else
        {
            m_SeenLastFrame = false;
        }
        if (m_CurrentGuaranteedAngerTimer > 0)
        {
            m_CurrentGuaranteedAngerTimer -= Time.deltaTime;
            
        }
        else
        {
            m_CurrentGuaranteedAngerTimer = 0;
        }
        //m_TimerText.text = m_CurrentGuaranteedAngerTimer.ToString();
        m_TimerText.text = m_EnemyState.ToString() + m_CurrentGuaranteedAngerTimer.ToString();
        m_LastFrameCostume = m_PlayerInfo.m_CostumeState;
    }
}

public enum EnemyState
{
    Friendly,
    Neutral,
    Aggresive
}
