using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for converting user LMB input into building spawn commands.
/// </summary>
[RequireComponent(typeof(Camera))]
public class UIBuilderController : MonoBehaviour
{
    [SerializeField] private List<MapBuildingConstraints> buildings = new List<MapBuildingConstraints>();
    [SerializeField] private List<MapEntity> units = new List<MapEntity>();

    int activeBuildingIndex = 0;

    private Camera cam;
    
    // step a bit over 50% of a one-unit-length-vector
    // to ensure that our RoundToInt function does mismap any integers, e.g. 1.0 - (1E-10) -> 0.0
    private const float normalStep = 0.55f;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // LMB + CTRL = delete
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    MapEntity entity;
                    if (hit.transform.TryGetComponent<MapEntity>(out entity))
                    {
                        Destroy(entity.gameObject);
                    }
                }
                
                // LMB
                else
                {
                    SubmeshFilter hitSubmeshFilter;
                    if (hit.transform.TryGetComponent<SubmeshFilter>(out hitSubmeshFilter))
                    {
                        // LMB + SHFT = spawn unit
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            GameObject go = Instantiate<GameObject>(units[activeBuildingIndex].gameObject, hit.point, Quaternion.identity);
                        }

                        // LMB without modifier = spawn building
                        else if (buildings[activeBuildingIndex].IsBuildingConstraintFulfilled(hitSubmeshFilter.biome))
                        {
                            GameObject cube = buildings[activeBuildingIndex].GetBuildingInstance();

                            // step in normal's direction
                            Vector3 p = hit.point + normalStep * hit.normal;
                            Vector3 clampedCubePoint = new Vector3(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), Mathf.RoundToInt(p.z));

                            cube.transform.position = clampedCubePoint;
                        }
                    }
                }
            }
        }
    }
}
