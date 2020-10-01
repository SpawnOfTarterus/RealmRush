using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof (Block))]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] TextMesh locationText = null;
    Block block;

    private void Awake()
    {
        block = GetComponent<Block>();
    }

    void Update()
    {
        SnapMechanic();
        UpdateLocationText();
    }

    private void SnapMechanic()
    {
        int gridSize = block.GetGridSize();
        Vector2Int snapPos = block.GetGridPos();
        transform.position = new Vector3(snapPos.x * gridSize, 0f, snapPos.y * gridSize);
    }

    private void UpdateLocationText()
    {
        int gridSize = block.GetGridSize();
        Vector2Int pos = block.GetGridPos();
        locationText.text = pos.x + "," + pos.y;
        string blockType = "Path";
        if(GetComponent<Wall>()) { blockType = "Wall"; }
        if(GetComponent<BuildLocation>()) { blockType = "Build Location"; }
        gameObject.name = blockType + " (" + pos.x + "," + pos.y + ")";
    }
}
