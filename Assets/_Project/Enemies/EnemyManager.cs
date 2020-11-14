using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private int numEnemies;
    
    [SerializeField] private BarrierShrinkage barrierRef;
    public List<BarrierShrinkData> barrierShrinkInfo = new List<BarrierShrinkData>();

    

    public List<GameObject> enemyList;

    
    
    //scriptable object for 
    //num enemies left - new shrink rate - bool for if applied yet or not

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        //look through list to see if we need to modify 

        //modify shrink rate if it hasn't been applied yet
    }

    public int GetNumEnemiesAlive()
    {
        return numEnemies;
    }

    public void GetEnemyDeathNotification(GameObject obj)
    {
        //delete object from enemy list
        if (enemyList.Contains(obj))
        {
            enemyList.Remove(obj);
            numEnemies = enemyList.Count;
            
            //check if this triggers any barrier shrink increases w/ new numEnemies

            foreach (BarrierShrinkData shrinkData in barrierShrinkInfo)
            {
                if (!shrinkData.hasBeenApplied() && numEnemies <= shrinkData.enemiesLeft)
                {
                    shrinkData.applyShrinkData();
                    barrierRef.ApplyShrinkRate(shrinkData.shrinkRate);

                    //break out early if we already encountered new rate
                    break;
                }
            }

        }
            
    }
}
