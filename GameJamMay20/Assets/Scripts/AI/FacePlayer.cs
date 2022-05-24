using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    bool facePlayer = true;

    Transform player;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (!facePlayer) return;

        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void AEvent_StartFacePlayer()
    {
        facePlayer = true;
    }

    public void AEvent_StopFacePlayer()
    {
        facePlayer = false;
    }
}
