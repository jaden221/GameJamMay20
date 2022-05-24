using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    bool facePlayer = true;

    SpriteRenderer sprite;
    Transform player;

	// if player is to the right then flip sprite if not then don't flip sprite
    //AEvent to turn this on and off*
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (!facePlayer) return;

        if (player.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
