using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpotting : MonoBehaviour
{
    [SerializeField] public EnemyInfo m_EnemyInfo;
    [SerializeField] public PlayerInfo m_PlayerInfo;
    [SerializeField] private float m_ChaseRange;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private float m_OriginalGuaranteedAngerTimer = 20;
    [SerializeField] private TextMeshProUGUI m_TimerText;
    [SerializeField] private float yoffset;
    public EnemyState m_EnemyState;

    private float m_CurrentGuaranteedAngerTimer;
    private float m_NotSeenPlayer = 0;
    private Ray m_Sight;
    [HideInInspector] public bool m_AggresiveToPlayer;
    private bool m_SeenLastFrame;
    private CostumeState m_LastFrameCostume;

    private void Start()
    {
        if (m_PlayerInfo == null)
        {
            m_PlayerInfo = GameObject.Find("Spine1").GetComponent<PlayerInfo>();
        }
        m_LastFrameCostume = m_PlayerInfo.m_CostumeState;
        
    }

    void Update()
    {
        m_Sight.origin = new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z);
        Vector3 playerPosition = new Vector3(m_PlayerInfo.transform.position.x, m_PlayerInfo.transform.position.y - yoffset, m_PlayerInfo.transform.position.x);
        m_Sight.direction = m_PlayerInfo.transform.position - transform.position;
        RaycastHit rayHit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(m_Sight, out rayHit, m_ChaseRange, 1 << 8 | 1 << 10))
        {
            if (rayHit.collider.gameObject.layer == 8)
            {
                Debug.DrawLine(m_Sight.origin, rayHit.point, Color.green);
                m_NotSeenPlayer = 0;
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
                    if (m_PlayerInfo.m_CostumeState != m_EnemyInfo.m_CostumeState || m_CurrentGuaranteedAngerTimer > 0)
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
                Debug.DrawLine(m_Sight.origin, rayHit.point, Color.red);
                m_NotSeenPlayer += Time.deltaTime;
                m_SeenLastFrame = false;

            }
        }
        else
        {
            m_SeenLastFrame = false;
            m_NotSeenPlayer += Time.deltaTime;
        }

        if (m_CurrentGuaranteedAngerTimer > 0)
        {
            m_CurrentGuaranteedAngerTimer -= Time.deltaTime;
            
        }
        else
        {
            m_CurrentGuaranteedAngerTimer = 0;
            if(m_NotSeenPlayer > 20)
            {
                m_EnemyState = EnemyState.Neutral;
                m_Animator.SetInteger("EnemyState", 1);
            }
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
