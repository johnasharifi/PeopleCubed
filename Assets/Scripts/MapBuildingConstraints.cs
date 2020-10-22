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
    
    /// <summary>
    /// A method for checking if the building can spawn.
    /// 
    /// Currently a-function-of-biome.
    /// </summary>
    /// <param name="proposedBiomeType">The biome which we wish to spawn a building in.</param>
    /// <returns>True if we can build this building in this biome.</returns>
    public bool IsBuildingConstraintFulfilled(int proposedBiomeType)
    {
        // for now, regen biomes each time the constraint is checked, since there are issues with constructor-time 
        // vars being edited during edit mode then starting play

        biomeTypes.Clear();
        biomeTypes.UnionWith(potentialBiomeTypes);
        return biomeTypes.Contains(proposedBiomeType);
    }

    // TODO pool
    public GameObject GetBuildingInstance()
    {
        return GameObject.Instantiate(building);
    }
}
