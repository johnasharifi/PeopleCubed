using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUnit : MapEntity
{
	[SerializeField] protected Vector3 targetPosition;
	[SerializeField] protected float moveSpeed = 10.0f;

	private void Update() {
	}
}
