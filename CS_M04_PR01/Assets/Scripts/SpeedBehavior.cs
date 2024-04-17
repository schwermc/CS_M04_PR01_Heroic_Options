using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    public float BoostMultiplier = 1.5f;
    public float BoostSeconds = 3f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Speed collected!");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostSpeed(BoostMultiplier, BoostSeconds);

            gameManager.Items += 1;
            gameManager.Speed += 1;
        }
    }
}
