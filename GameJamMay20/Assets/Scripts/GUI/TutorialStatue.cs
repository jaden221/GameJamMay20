using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStatue : MonoBehaviour
{
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.GetComponent<PlayerController>())
        {
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.transform.root.GetComponent<PlayerController>())
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
