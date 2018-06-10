using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MeshToPrefab: MonoBehaviour {

	[ContextMenu("Convert to regular mesh")]
	public void ConverToRegularMesh()
	{
		SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer> ();
		meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter> ();
		meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;

		DestroyImmediate (skinnedMeshRenderer);
		DestroyImmediate (this);
	}

}
