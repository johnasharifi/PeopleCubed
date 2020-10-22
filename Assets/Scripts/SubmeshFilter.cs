using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for storing the biome associated with a submesh.
/// </summary>
[RequireComponent(typeof(MeshFilter))]
public class SubmeshFilter : MonoBehaviour
{
    [SerializeField] private int m_biome;
    public int biome
    {
        set
        {
            m_biome = value;
        }
        get
        {
            return m_biome;
        }
    }
}
