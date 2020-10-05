using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Heightmap))]
public class SpawnPrefabsFromHeightmap : MonoBehaviour
{
    [SerializeField] private Heightmap heightmap;
    // Start is called before the first frame update
    void Awake()
    {
        Dictionary<int, MaterialPropertyBlock> biomeMatBlocks = new Dictionary<int, MaterialPropertyBlock>();
        foreach (int key in heightmap.colorLookupTable.Keys)
        {
            Color c = heightmap.colorLookupTable[key];

            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, c);
            tex.Apply();

            biomeMatBlocks[key] = new MaterialPropertyBlock();
            biomeMatBlocks[key].SetTexture("_MainTex", tex);
        }
        
        heightmap.onBiomesGenerated += (int biome, int x, int z, Color c) =>
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(x, 0f, z);
            go.GetComponent<Renderer>().material.color = heightmap.colorLookupTable[biome];
            go.transform.SetParent(heightmap.transform);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
