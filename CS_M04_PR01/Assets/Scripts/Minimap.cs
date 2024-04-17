using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public GameObject minimap;

    private bool rotate = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            minimap.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            minimap.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (rotate)
            {
                rotate = false;
            }
            else
            {
                rotate = true;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = player.position.y + 7;
        transform.position = newPosition;

        // Rotate with player code

        if (rotate)
        {
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(90f, 180f, 0f);
        }
    }
}
