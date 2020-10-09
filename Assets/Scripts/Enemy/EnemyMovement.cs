using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    PathFinder pathfinder = null;
    [SerializeField] Block lastBlockVisited = null;
    public bool levelLost = false;

    private void Start()
    {
        pathfinder = FindObjectOfType<PathFinder>();
        FindAndFollowPath();
    }

    private void FindAndFollowPath()
    {
        var path = pathfinder.PathFind();
        StartCoroutine(MoveAlongPath(path));
    }

    IEnumerator MoveAlongPath(List<Block> path)
    {
        for(int block = 0; block < path.Count; block++)
        {
            if(levelLost) { yield break; }
            Vector3 destination = new Vector3(path[block].transform.position.x, transform.position.y, path[block].transform.position.z);
            transform.LookAt(destination);
            while(transform.position != destination && !levelLost)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
                yield return null;
            }
            lastBlockVisited = path[block];
        }
        yield return null;
        if (lastBlockVisited == pathfinder.GetEndBlock() && !levelLost)
        {
            GetComponent<Enemy>().ExploadOnTarget();
        }
    }
}
