using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBehavior : MonoBehaviour
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
            Debug.Log("Follower collected!");

            //PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            //Player.CloneFollower();

            gameManager.Items += 1;
            gameManager.Follower += 1;
        }
    }
}
