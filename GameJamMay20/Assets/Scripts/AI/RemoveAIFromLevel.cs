using UnityEngine;

public class RemoveAIFromLevel : MonoBehaviour
{
    Health health;
    LevelHandeler levelHandeler;
	
    void Awake()
    {
        health = GetComponent<Health>();
        levelHandeler = FindObjectOfType<LevelHandeler>();
    }

    void OnEnable()
    {
        health.OnDeath += HandleOnDeath;
    }

    void OnDisable()
    {
        health.OnDeath -= HandleOnDeath;
    }

    void HandleOnDeath()
    {
        levelHandeler.RemoveEnemy();
    }
}
