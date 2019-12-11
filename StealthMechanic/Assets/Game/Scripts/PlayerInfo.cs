﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public CostumeState m_CostumeState;
    [SerializeField] private SkinnedMeshRenderer m_MeshRenderer;

    public void Update()
    {
        if(m_CostumeState == CostumeState.Blue)
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCostumeState(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCostumeState(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCostumeState(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeCostumeState(3);
        }
    }

    public void ChangeCostumeState(int costumeState)
    {
        if(costumeState == 0)
        {
            m_CostumeState = CostumeState.Blue;
        }
        else if (costumeState == 1)
        {
            m_CostumeState = CostumeState.Red;
        }
        else if (costumeState == 2)
        {
            m_CostumeState = CostumeState.Green;
        }
        else if (costumeState == 3)
        {
            m_CostumeState = CostumeState.Black;
        }

    }
}

public enum CostumeState
{
    Blue,
    Red,
    Green,
    Black
}

