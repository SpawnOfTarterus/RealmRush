using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    [SerializeField] Block startBlock = null, endBlock = null;
    Vector2Int[] directions =
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };
    Queue<Block> queue = new Queue<Block>();
    bool isRunning = true;
    Block searchCenter = null;

    public Block GetEndBlock()
    {
        return endBlock;
    }

    private void ResetPathFinder()
    {
        queue.Clear();
        grid.Clear();
        searchCenter = null;
    }

    public List<Block> PathFind()
    {
        LoadBlocks();
        queue.Enqueue(startBlock);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            if(searchCenter == endBlock)
            {
                //Debug.Log("goal found");
                isRunning = false;
            }
            ExploreNeighbors();
        }
        if (isRunning) { Debug.Log("Done Search Goal Not Found"); ResetPathFinder(); return null; }
        return GetPath();
    }

    private List<Block> GetPath()
    {
        List<Block> path = new List<Block>();
        for(Block thisBlock = endBlock; thisBlock != startBlock; thisBlock = thisBlock.foundFrom)
        {
            path.Add(thisBlock);
        }
        path.Reverse();
        return path;
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            var exploredPosition = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(exploredPosition))
            {
                if(grid[exploredPosition].explored || queue.Contains(grid[exploredPosition])) { continue; }
                queue.Enqueue(grid[exploredPosition]);
                grid[exploredPosition].explored = true;
                grid[exploredPosition].foundFrom = searchCenter;
            }
        }
    }

    private void LoadBlocks()
    {
        var blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks)
        {
            var gridPos = block.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                continue;
            }
            if(block.GetComponent<Wall>())
            {
                continue;
            }
            if (block.GetComponent<BuildLocation>())
            {
                if(block.GetComponent<BuildLocation>().GetLocationStatus())
                {
                    Debug.Log("tower build here");
                    continue;
                }
            }
            grid.Add(gridPos, block);
            block.explored = false;
        }
    }
}
