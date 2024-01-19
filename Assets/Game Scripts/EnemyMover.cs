using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed;
    BaseDamager friendlyBase;
    [SerializeField] List<CheckPoint> path;


    void Start()
    {
        friendlyBase = FindObjectOfType<BaseDamager>();
        path = GetComponentInParent<PathFinder>().GetPath();
        
        StartCoroutine(FollowEnemyPath(path));

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator FollowEnemyPath(List<CheckPoint> path) //IEnumerator = a countable figure
    {
  
        foreach (CheckPoint checkPoint in path)
        {

            Vector2Int rawNextBlock = checkPoint.GetSnapLocation() * checkPoint.GetSnapSize();

            Vector3 nextBlock = new Vector3(rawNextBlock.x, 0f, rawNextBlock.y);

            transform.position = nextBlock;
            
            yield return new WaitForSeconds(enemySpeed);

        }

        
        friendlyBase.ReduceHealth();
        Destroy(gameObject);
    }

    

       

    
    

}
