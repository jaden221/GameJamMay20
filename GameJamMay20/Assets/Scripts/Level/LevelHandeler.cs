using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{
    int enemyCounter;
    ZoneLoader activeZone;
    bool zoneReady = true;

    public void AddEnemy()
    {
        enemyCounter++;
    }

    public void RemoveEnemy()
    {
        enemyCounter--;
    }

    //ZoneLoader will call this to make itself active when player enters
    public void SetActiveZone(ZoneLoader newActiveZone)
    {
        activeZone = newActiveZone;
    }

    //This is to make sure the level handeler doesn't accidentally open the gates before enemies spawn.
    //I am not sure if this is necessary because I haven't tested if its a bug that will happen. But better safe.
    public void IsZoneReady(bool isZoneReady)
    {
        zoneReady = isZoneReady;
    }

    //removes barriers when all enemies are dead
    private void Update()
    {
        if(activeZone != null && enemyCounter <= 0 && zoneReady) { activeZone.OpenGates(); }
    }
}
