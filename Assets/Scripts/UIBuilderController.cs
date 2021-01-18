﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for converting user LMB input into building spawn commands.
/// </summary>
[RequireComponent(typeof(Camera))]
public class UIBuilderController : MonoBehaviour
{
    [SerializeField] private List<MapBuildingConstraints> buildings = new List<MapBuildingConstraints>();
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // LMB + CTRL = delete
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    MapBuilding building;
                    if (hit.transform.TryGetComponent<MapBuilding>(out building))
                    {
                        Destroy(building.gameObject);
                    }
                }

                // LMB + no modifier = spawn a building
                else
                {
                    SubmeshFilter hitSubmeshFilter;
                    if (hit.transform.TryGetComponent<SubmeshFilter>(out hitSubmeshFilter))
                    {
                        if (buildings[activeBuildingIndex].IsBuildingConstraintFulfilled(hitSubmeshFilter.biome))
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
