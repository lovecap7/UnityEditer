using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    public static int m_id = 0;
    public int m_myID = 0;
    private void Awake()
    {
        ++m_id;
        m_myID = m_id;
    }
}
