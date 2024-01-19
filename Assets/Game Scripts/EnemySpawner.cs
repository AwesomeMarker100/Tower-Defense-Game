using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 8)] [SerializeField] float secondsBetweenSpawn;
    [SerializeField] EnemyMover enemyPrefab;
    AudioSource af;
    BaseDamager bd;



    // Start is called before the first frame update
    void Start()
    {
        af = GetComponent<AudioSource>();
        bd = FindObjectOfType<BaseDamager>();

        
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    

    IEnumerator SpawnEnemy()
    {


        while (true)
        {

            EnemyMover enemyClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            if(bd.GetHealth() <= 10)
            {
                enemyClone.enemySpeed -= 0.3f;
                FindObjectOfType<TowerMill>().maxTowers = 9;
                enemyClone.GetComponent<EnemyDamager>().maxHits++;

            }
            af.Play();

            enemyClone.transform.parent = transform; 
            yield return new WaitForSeconds(secondsBetweenSpawn);
            
        }

        

    }
}
