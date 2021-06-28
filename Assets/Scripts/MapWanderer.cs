using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWanderer : MapUnit
{
	[SerializeField] private Vector3 randomTargetSpan;
	[SerializeField] private Vector3 randomTargetCenter;

	private void Start() {
		StartCoroutine(CRRandomizeTargetPosition());
	}

	IEnumerator CRRandomizeTargetPosition() {
		const float waitTime = 1.5f;
		WaitForSeconds waiter = new WaitForSeconds(waitTime);

		for (; ; ) {
			targetPosition = randomTargetCenter + Vector3.Scale(new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f), randomTargetSpan);
			yield return waiter;
		}
	}

	// Update is called once per frame
	void Update()
    {
		Vector3 targetDirection = targetPosition - transform.position;
		transform.LookAt(targetDirection);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
