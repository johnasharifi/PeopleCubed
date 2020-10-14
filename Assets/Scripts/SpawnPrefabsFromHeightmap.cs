using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Heightmap))]
public class SpawnPrefabsFromHeightmap : MonoBehaviour
{
    [SerializeField] private Heightmap heightmap;

    [SerializeField] private List<GameObject> submaps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<int, Material> materials = GetBiomeMapResourcePairs();
        Dictionary<int,Mesh> meshes = BiomeToFloodfilledMesh.GetMeshesFromHeightmap(heightmap);

        foreach (KeyValuePair<int, Mesh> pair in meshes)
        {
            GameObject submap = new GameObject("submesh " + (pair.Key >= 0? " ": "") + pair.Key.ToString("D2"));
            MeshFilter mf = submap.AddComponent<MeshFilter>();
            MeshRenderer mr = submap.AddComponent<MeshRenderer>();

            mf.mesh = pair.Value;
            mr.material = materials[pair.Key];

            submap.transform.SetParent(this.transform);
            submap.transform.localRotation = Quaternion.identity;

            submap.AddComponent<MeshCollider>();
        }
    }

    static Dictionary<int, Material> GetBiomeMapResourcePairs()
    {
        Dictionary<int, Material> resources = new Dictionary<int, Material>();
        resources[-1] = Resources.Load<Material>("MatWhiteInstance");
        resources[+1] = Resources.Load<Material>("MatWhiteInstance");
        resources[10] = Resources.Load<Material>("MatWhiteInstance");
        resources[5] = Resources.Load<Material>("MatBlueInstance");
        resources[0] = Resources.Load<Material>("MatRedInstance");
        resources[9] = Resources.Load<Material>("MatRedInstance");
        resources[7] = Resources.Load<Material>("MatOrangeInstance");
        resources[8] = Resources.Load<Material>("MatGreenInstance");
        return resources;
    }

}
