using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int numEnemies;
    
    [SerializeField] private BarrierShrinkage barrierRef;
    public List<BarrierShrinkData> barrierShrinkInfo = new List<BarrierShrinkData>();

    public List<GameObject> enemyList = new List<GameObject>();

    public Flock[] flockList;

    public TextMeshProUGUI enemyListNum;
    public TextMeshProUGUI loseWinPanelText;

    private string loseWinText = "You outlasted 0 enemies!\nBetter luck next time!";

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

        int aggressiveShips = Random.Range(45, 70);
        int cowardShips = 99 - aggressiveShips;

        flockList[0].startingCount = aggressiveShips;
        flockList[1].startingCount = cowardShips;
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

    public void CheckForBarrierUpdate()
    {
        foreach (BarrierShrinkData shrinkData in barrierShrinkInfo)
        {
            if (!shrinkData.hasBeenApplied() && numEnemies <= shrinkData.enemiesLeft)
            {
                Debug.Log("Shrink data null: " + (shrinkData == null).ToString());
                shrinkData.applyShrinkData();
                barrierRef.ApplyShrinkRate(shrinkData.shrinkRate);

                //break out early if we already encountered new rate
                break;
            }
        }
    }

    public void AddToEnemyList(GameObject obj)
    {
        enemyList.Add(obj);
    }

    public void GetFinalText()
    {
        string newLoseText = "";

        if (numEnemies > 0)
        {
            newLoseText = "You outlasted " + (99 - numEnemies) + " enemies!\nBetter luck next time!";
        }
        else
        {
            newLoseText = "You outlasted the competition!\nGood job!";
        }

        loseWinPanelText.text = newLoseText;
    }

    public void GetEnemyDeathNotification(GameObject obj)
    {
        //delete object from enemy list
        if (enemyList.Contains(obj))
        {
            enemyList.Remove(obj);
            numEnemies = enemyList.Count;

            //check if this triggers any barrier shrink increases w/ new numEnemies

            CheckForBarrierUpdate();

            enemyListNum.text = numEnemies.ToString();

        }
            
    }
}
