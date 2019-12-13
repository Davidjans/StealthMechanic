using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLocation : MonoBehaviour
{
    [SerializeField] private Transform m_ObjectToFollow;
    // Update is called once per frame
    void Update()
    {
        transform.position = m_ObjectToFollow.position;
        transform.rotation = m_ObjectToFollow.rotation;
    }
}
