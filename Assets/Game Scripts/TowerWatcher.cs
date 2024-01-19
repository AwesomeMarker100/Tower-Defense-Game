using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWatcher : MonoBehaviour
{

    [SerializeField] Transform focusObject;
    [SerializeField] int attackRange;
    [SerializeField] ParticleSystem bullets;

    CheckPoint placer;
    
    Transform targetEnemy;
    EnemyDamager[] enemies;

    // Start is called before the first frame update
    void Start()
    {



    }

    public CheckPoint GetPlacer()
    {

        return placer;

    }

    public void SetPlacer(CheckPoint placer)
    {

        this.placer = placer;

    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();


        if (targetEnemy)
        {

            LookAtEnemy();
            FireAtEnemy();

        }
        else
        {

            Shoot(false);

        }
        

    }
    
    void SetTargetEnemy()
    {
        enemies = FindObjectsOfType<EnemyDamager>();
        if(enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyDamager enem in enemies)
        {
            closestEnemy = CalculateTargetEnemy(enem.transform, closestEnemy);

        }

        targetEnemy = closestEnemy;

    }

    Transform CalculateTargetEnemy(Transform a, Transform b)
    {

        float distanceA = Vector3.Distance(a.position, transform.position);
        float distanceB = Vector3.Distance(b.position, transform.position);

        if(distanceA < distanceB)
        {

            return a;

        }

        return b;

    }
  


    private void LookAtEnemy() 
    {
       
        focusObject.LookAt(targetEnemy);
        
    }
    
    private void FireAtEnemy()
    {

        float distanceFromEnemy = Vector3.Distance(targetEnemy.transform.position, this.transform.position);

        if (distanceFromEnemy <= attackRange)
        {

            Shoot(true);

        }
        else
        {

            Shoot(false);

        }

    }
    

    void Shoot(bool isShooting)
    {

        var emissionModule = bullets.emission;

        emissionModule.enabled = isShooting;

        
    }
    
    
}
