using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int numEnemies;
    
    [SerializeField] private BarrierShrinkage barrierRef;
    public List<BarrierShrinkData> barrierShrinkInfo = new List<BarrierShrinkData>();

    public List<GameObject> enemyList = new List<GameObject>();

    public Flock[] flockList;

    public TextMeshProUGUI enemyListNum;

    //scriptable object for 
    //num enemies left - new shrink rate - bool for if applied yet or not

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy manager start");

        foreach (Flock f in flockList)
        {
            f.enemyManagerRef = this;
        }
    }

    void Awake()
    {
        //load up enemy list
        
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

    public void ForceEnemyDisplayUpdate()
    {
        numEnemies = enemyList.Count;
        enemyListNum.text = numEnemies.ToString();
    }

    public void AddToEnemyList(GameObject obj)
    {
        enemyList.Add(obj);
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

            enemyListNum.text = numEnemies.ToString();

        }
            
    }
}
