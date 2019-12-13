using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    [SerializeField] public bool m_DoorState;
    [SerializeField] public Transform m_DoorTransform;
    [SerializeField] public float m_DoorMaxHeight;
    [SerializeField] public float m_DoorMinHeight;

    void Update()
    {
        if (m_DoorState == true)
        {
            MoveDoorUp();
        }
        else if (m_DoorState == false)
        {
            MoveDoorDown();
        }
    }

    public void MoveDoor()
    {
        if(m_DoorState == true)
        {
            m_DoorState = false;
        }
        else if (m_DoorState == false)
        {
            m_DoorState = true;
        }
    }

    private void MoveDoorUp()
    {
        if (m_DoorTransform.localPosition.y < m_DoorMaxHeight)
        {
            m_DoorTransform.localPosition = new Vector3(m_DoorTransform.localPosition.x, m_DoorTransform.localPosition.y + 0.1f, m_DoorTransform.localPosition.z);
        }
        else
        {
            m_DoorTransform.localPosition = new Vector3(m_DoorTransform.localPosition.x, m_DoorMaxHeight, m_DoorTransform.localPosition.z);
        }
    }

    private void MoveDoorDown()
    {
        if (m_DoorTransform.localPosition.y > m_DoorMinHeight)
        {
            m_DoorTransform.localPosition = new Vector3(m_DoorTransform.localPosition.x, m_DoorTransform.localPosition.y - 0.1f, m_DoorTransform.localPosition.z);
        }
        else
        {
            m_DoorTransform.localPosition = new Vector3(m_DoorTransform.localPosition.x, m_DoorMinHeight, m_DoorTransform.localPosition.z);
        }
    }


}
