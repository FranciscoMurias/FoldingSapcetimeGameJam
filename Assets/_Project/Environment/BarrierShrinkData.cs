using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Environment/BarrierData")]
public class BarrierShrinkData : ScriptableObject
{
    public int enemiesLeft;
    public float shrinkRate;
    private bool applied = false;

    public void applyShrinkData()
    {
        applied = true;
    }

    public void reenableShrinkData()
    {
        applied = false;
    }

    public bool hasBeenApplied()
    {
        return applied;
    }
}
