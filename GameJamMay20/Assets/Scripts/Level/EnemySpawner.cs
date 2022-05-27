using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Set which enemy you want it to be.
    [SerializeField] EnemyController enemy;
    
    /*Pretty self explanitory.
     *Add an enemy spawner in the editor
     *and set the enemy you want it to spawn.
     When the player enters an enemy will spawn where you set the spawner to be.*/
    internal void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
