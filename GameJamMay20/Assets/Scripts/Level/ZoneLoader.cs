using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLoader : MonoBehaviour
{
    [Tooltip("For setting where the camera is going to go when the player enters the area. You can set this to the coordinates of where the new ground is at as the ground prefab is the exact size of the camera.")]
    [SerializeField] Vector3 newCameraPos;
    [Tooltip("Set all the enemy spawners you want in the zone in this array. Make sure the spawners are actually in this zone so you dont spawn enemies in other zones.")]
    [SerializeField] EnemySpawner[] enemySpawners;
    [Tooltip("Place the gate objects in here")]
    [SerializeField] GameObject[] gates;
    [Tooltip("Place Images of what the open gates will look like in the same order the gates are in")]
    [SerializeField] List<Sprite> openGates;
    [Tooltip("Set an empty at the location you want the player to start in the new zone in here.")]
    [SerializeField] Transform playerStartPoint;
    [SerializeField] float cameraTransitionSpeed = 2f;
    [SerializeField] float playerTransitionSpeed = 2f;

    GameObject player;
    LevelHandeler levelHandeler;
    

    public void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        levelHandeler = FindObjectOfType<LevelHandeler>();
    }

    

    /*This one does a lot of stuff so buckle up
    when the player hits this trigger to enter next zone we are going to set ourselves as the active zone.
    then we are going to move the player to where we want him to start. 
    To do this you will add a empty gameobject and set it as the playerStartPoint in the editor.
    Then place the empty where you want the player to start.
    Then it will take all the enemy spawners you have added to this loader and tell them to spawn there enemies
    and also tell the level handeler we spawned the enemies.
    Also to be safe we are going to disable Opening gates until we do all this so the enemy counter doesnt intantly say
    "hey we hadnt spawned any enemies yet lets just open gates now"
    */
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.root.GetComponent<PlayerController>()) 
        {
            levelHandeler.SetActiveZone(this);
            levelHandeler.IsZoneReady(false);
            Transition();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                EnemySpawner spawner = enemySpawners[i];
                spawner.SpawnEnemy();
                levelHandeler.AddEnemy();
            }
            levelHandeler.IsZoneReady(true); 
        }
    }

    internal void OpenGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            GameObject gate = gates[i];
            if (openGates.Count == 0)
            {
                gate.SetActive(false);
            }
            if(openGates.Count != 0)
            {
                Sprite openGate = openGates[i];
                gate.GetComponent<SpriteRenderer>().sprite = openGate;
                gate.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    

    IEnumerator LerpPosition(GameObject objectToMove, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = objectToMove.transform.position;
        while (time < duration)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        objectToMove.transform.position = targetPosition;
    }

    private void Transition()
    {
        player.GetComponent<PlayerController>().DisableMove();
        StartCoroutine(LerpPosition(Camera.main.gameObject, newCameraPos, cameraTransitionSpeed));
        StartCoroutine(LerpPosition(player, playerStartPoint.position, playerTransitionSpeed));
        player.GetComponent<PlayerController>().EnableMove();
    }
}
