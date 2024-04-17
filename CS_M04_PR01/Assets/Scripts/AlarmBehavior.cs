using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Alarm sounded!");

            gameManager.Items += 1;
        }
    }
}
