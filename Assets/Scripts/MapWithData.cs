using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A 2D array of name-float pairs. This data structure will store core game info in a way that is relatively sparse.
/// </summary>
public class MapWithData : MonoBehaviour
{
	private class FloatLookup : Dictionary<string, float> { };

	const int dimensions = 100;

	FloatLookup[,] data = new FloatLookup[dimensions, dimensions];

	public float this[int i, int j, string name] {
		get {
			if (data[i, j] == null) {
				data[i, j] = new FloatLookup();
			}

			if (!data[i, j].ContainsKey(name)) {
				data[i, j][name] = default;
			}

			return data[i, j][name];
		}
	}
}
