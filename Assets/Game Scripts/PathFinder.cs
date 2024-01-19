using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, CheckPoint> grid = new Dictionary<Vector2Int, CheckPoint>();
    Queue<CheckPoint> checkPointQueue = new Queue<CheckPoint>();
    List<CheckPoint> path = new List<CheckPoint>();

    [SerializeField] CheckPoint start;
    [SerializeField] CheckPoint end;

    List<CheckPoint> queueRemnants = new List<CheckPoint>();

    bool queueIsRunning = true;
    CheckPoint searchBase;

    Vector2Int[] directions = {

        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left


    };


    // Start is called before the first frame update

    void Start()
    {

        LoadGrid();

    }

    private void LoadGrid()
    {
        CheckPoint[] checkPoints = FindObjectsOfType<CheckPoint>();

        foreach (CheckPoint checkPoint in checkPoints)
        {

            Vector2Int snapLocation = checkPoint.GetSnapLocation();

            bool isOverlapping = grid.ContainsKey(snapLocation);

            if (isOverlapping)
            {

                Debug.LogWarning("Overlapping block at " + checkPoint.name);


            }
            else
            {

                grid.Add(snapLocation, checkPoint);

            }
        }

        print(grid.Count + " blocks have loaded.");

    }


    public void MakePath()
    {
 
        path.Add(end);
        end.isUsable = false;
        

        while (path[path.Count - 1] != start)
        {
            CheckPoint nextPoint = path[path.Count - 1].exploredFrom;
            nextPoint.isUsable = false;
            path.Add(nextPoint);

        }

        path.Reverse();

        
    }
    
    public void CleanUpPath()
    {

        foreach(CheckPoint a in queueRemnants)
        {

            if (!path.Contains(a))
            {

                a.isExplored = false;
                a.exploredFrom = null;
                a.isUsable = true;

            }

        }

    }

    public List<CheckPoint> GetPath()
    {
        if(path.Count == 0)
        {

            BreadthFirstSearch();
            MakePath();
            CleanUpPath();

        }
        
        return (path);

    }


    public void BreadthFirstSearch()
    {
        checkPointQueue.Enqueue(start);
        while (checkPointQueue.Count > 0 && queueIsRunning)
        {

            searchBase = checkPointQueue.Dequeue();//dequeue deletes first thing from queue
            CheckIfEndFound();
            FindNeighbors();
            
            searchBase.isExplored = true;
            queueRemnants.Add(searchBase);
            
        }

    }

    private void CheckIfEndFound()
    {

        if (searchBase == end)
        {
            print("Found end.");
            queueIsRunning = false;

        }


    }

    private void FindNeighbors()
    {

        if (!queueIsRunning) { return; }

        

        foreach (Vector2Int direction in directions)
        {

            Vector2Int neighborCoords = searchBase.GetSnapLocation() + direction;

            if (grid.ContainsKey(neighborCoords))
            {

                QueueNeighbor(neighborCoords);

            }
        }
    }

    private void QueueNeighbor(Vector2Int neighborCoords)
    {

        CheckPoint neighborBlock = grid[neighborCoords];

        if (neighborBlock.isExplored || checkPointQueue.Contains(neighborBlock))
        {
        }
        else { 

            

            checkPointQueue.Enqueue(neighborBlock);

            neighborBlock.exploredFrom = searchBase;


        }
        
    }




}
