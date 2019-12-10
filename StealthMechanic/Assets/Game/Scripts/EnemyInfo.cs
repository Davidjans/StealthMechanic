using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private CostumeState m_CostumeState;
    [SerializeField] private SkinnedMeshRenderer m_MeshRenderer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CostumeState == CostumeState.Blue)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = Color.blue;
            }
        }
        else if (m_CostumeState == CostumeState.Red)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = Color.red;
            }
        }
        else if (m_CostumeState == CostumeState.Green)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = Color.green;
            }
        }
        else if (m_CostumeState == CostumeState.Black)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = Color.black;
            }
        }
    }

    public void ChangeCostumeState(CostumeState costumeState)
    {
        m_CostumeState = costumeState;
    }
}
