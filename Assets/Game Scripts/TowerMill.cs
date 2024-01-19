using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMill : MonoBehaviour
{

    [SerializeField] TowerWatcher towerPrefab;
    [SerializeField] Transform parentTransform;
    public int maxTowers = 0;

    Queue<TowerWatcher> stackOfTowers = new Queue<TowerWatcher>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(CheckPoint placer) {

        if (maxTowers > 0)
        {
            TowerWatcher towerClone = InstantiateTower(placer);
            QueueTower(towerClone);
        }
        else
        {

            MoveFirstTower(placer);

        }
    }

    void QueueTower(TowerWatcher towerClone)
    {
        stackOfTowers.Enqueue(towerClone);
        maxTowers--;

    }

    TowerWatcher InstantiateTower(CheckPoint placer)
    {

        TowerWatcher towerClone = Instantiate(towerPrefab, placer.transform.position, Quaternion.identity);
        towerClone.transform.parent = parentTransform;
        towerClone.SetPlacer(placer);

        return towerClone;

    }
    void MoveFirstTower(CheckPoint placer)
    {

        TowerWatcher firstTower = stackOfTowers.Dequeue();

        firstTower.GetPlacer().isUsable = true;
        firstTower.transform.position = placer.transform.position;
        firstTower.SetPlacer(placer);

        stackOfTowers.Enqueue(firstTower);

    }
}
