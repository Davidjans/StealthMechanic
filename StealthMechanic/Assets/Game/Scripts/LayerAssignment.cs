using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerAssignment : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Objects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_Objects.Count; i++)
        {
            m_Objects[i].layer = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
