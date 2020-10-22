using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for managing validation and spawn operations for a building on the game map.
/// </summary>
[System.Serializable]
public class MapBuildingConstraints
{
    // serializable collection of biome types to do IO with
    [SerializeField] private List<int> potentialBiomeTypes = new List<int>();
    [SerializeField] private GameObject building;

    HashSet<int> biomeTypes = new HashSet<int>();

    private MapBuildingConstraints()
    {
        biomeTypes = new HashSet<int>(potentialBiomeTypes);
    }
    
    /// <summary>
    /// A method for checking if the building can spawn.
    /// 
    /// Currently a-function-of-biome.
    /// </summary>
    /// <param name="proposedBiomeType">The biome which we wish to spawn a building in.</param>
    /// <returns>True if we can build this building in this biome.</returns>
    public bool IsBuildingConstraintFulfilled(int proposedBiomeType)
    {
        return biomeTypes.Contains(proposedBiomeType);
    }

    // TODO pool
    public GameObject GetBuildingInstance()
    {
        return GameObject.Instantiate(building);
    }
}
