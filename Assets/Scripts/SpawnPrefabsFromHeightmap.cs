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
        Dictionary<int, GameObject> resources = GetBiomeMapResourcePairs();

        heightmap.onBiomesGenerated += (int biome, int x, int z, Color c) =>
        {
            // GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject go = Instantiate<GameObject>(resources[biome]);
            go.transform.position = new Vector3(x, 0f, z);
            // go.GetComponent<Renderer>().material.color = heightmap.colorLookupTable[biome];
            go.transform.SetParent(heightmap.transform);
        };
    }

    static Dictionary<int,GameObject> GetBiomeMapResourcePairs()
    {
        Dictionary<int, GameObject> resources = new Dictionary<int, GameObject>();
        resources[-1] = Resources.Load<GameObject>("PrefabBiomeEmpty");
        resources[+1] = Resources.Load<GameObject>("PrefabBiomeEmpty");
        resources[10] = Resources.Load<GameObject>("PrefabBiomeEmpty");
        resources[5] = Resources.Load<GameObject>("PrefabBiomeWater");
        resources[0] = Resources.Load<GameObject>("PrefabBiomeMountain");
        resources[9] = Resources.Load<GameObject>("PrefabBiomeMountain");
        resources[7] = Resources.Load<GameObject>("PrefabBiomePlains");
        resources[8] = Resources.Load<GameObject>("PrefabBiomeForest");
        return resources;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
