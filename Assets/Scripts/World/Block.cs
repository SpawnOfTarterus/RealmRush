using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool explored = false;
    public Block foundFrom = null;
    const int gridSize = 10;
    Vector2Int gridPos;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        int xPos = Mathf.RoundToInt(transform.position.x / gridSize);
        int zPos = Mathf.RoundToInt(transform.position.z / gridSize);
        gridPos = new Vector2Int(xPos, zPos);
        return gridPos;
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<SelectionController>().GetSelection(gameObject);
        }
    }
}
