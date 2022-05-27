using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{
    //You actually don't have to public or serialize or mess with these. So that's cool.
    int enemyCounter;
    ZoneLoader activeZone;
    bool zoneReady = true;

    //functions to add and remove enemies
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
        if(enemyCounter <= 0 && zoneReady) { activeZone.OpenGates(); }
    }
}
