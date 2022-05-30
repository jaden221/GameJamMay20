using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStatue : MonoBehaviour
{
    [SerializeField]GameObject canvas;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.GetComponent<PlayerController>())
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.transform.root.GetComponent<PlayerController>())
        {
            canvas.SetActive(false);
        }
    }
}
