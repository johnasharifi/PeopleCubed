using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Class for storing the biome associated with a submesh.
/// </summary>
[RequireComponent(typeof(MeshFilter))]
public class SubmeshFilter : MonoBehaviour
{
    [SerializeField] private Heightmap m_Heightmap;
    public Heightmap Heightmap
    {
        get
        {
            if (m_Heightmap == null) m_Heightmap = GetComponentInParent<Heightmap>();
            return m_Heightmap;
        }
    }

    [SerializeField] private Renderer m_Renderer;
    public Renderer Renderer
    {
        get
        {
            if (m_Renderer == null) m_Renderer = GetComponent<Renderer>();
            return m_Renderer;
        }
    }
    
    const float gridTranslate = 0.5f;
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

    private void OnEnable()
    {
        if (Heightmap != null)
        {
            // apply a translation to grid
            MeshFilter mf = GetComponent<MeshFilter>();
            Renderer.material.SetTextureScale("_MainTex", Vector2.one * Heightmap.getDim(0));
            mf.mesh.SetUVs(0, mf.mesh.vertices.ToList().Select(x => new Vector3((x.x - gridTranslate) / Heightmap.getDim(0), (x.y - gridTranslate) / Heightmap.getDim(0), 0.5f)).ToList());
        }
    }
}
