using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLoader : MonoBehaviour
{
    //For setting where the camera is going to go when the player enters the area
    //You can set this to the coordinates of where the new ground is at as the ground prefab is the exact size of the camera.
    [SerializeField] Vector3 newCameraPos;
    //Set all the enemy spawners you want in the zone in this array.
    //make sure the spawners are actually in this zone so you dont spawn enemies in other zones.
    [SerializeField] EnemySpawner[] enemySpawners;
    //Set the gates that are going to open up in this array in editor.
    //Since there isnt a gate opening animation right now these gates will just get disabled.
    [SerializeField] GameObject[] gates;
    //Set an empty at the location you want the player to start in the new zone in here.
    [SerializeField] Transform playerStartPoint;

    [SerializeField] float cameraTransitionSpeed = .5f;

    [SerializeField] float playerTransitionSpeed = .5f;

    GameObject player;
    LevelHandeler levelHandeler;
    [SerializeField] bool isZoneReady = true;
    

    public void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        levelHandeler = FindObjectOfType<LevelHandeler>();
    }

    private void Update()
    {
        if (isZoneReady == false)
        {
            Transition();
        }

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
            isZoneReady = false;
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
            gate.SetActive(false);
        }
    }

    private void Transition()
    {
        player.GetComponent<PlayerController>().DisableMove();
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCameraPos,  cameraTransitionSpeed);
        player.transform.position = Vector2.Lerp(player.transform.position, playerStartPoint.position, playerTransitionSpeed);
        if(Vector3.Distance(Camera.main.transform.position, newCameraPos) <= 0.1f && Vector2.Distance(player.transform.position, playerStartPoint.position) <= 0.1f)
        {
            Camera.main.transform.position = newCameraPos;
            player.transform.position = playerStartPoint.position;
            player.GetComponent<PlayerController>().EnableMove();
            isZoneReady = true;
        }
        
    }
}
