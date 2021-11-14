using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;

    public float incrementOffset;
    public float speed;

    public string sortingLayer;
    public int orderInLayer;

    private float offset;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;

        currentMaterial = meshRenderer.material;
    }

    void FixedUpdate()
    {
        offset += incrementOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
