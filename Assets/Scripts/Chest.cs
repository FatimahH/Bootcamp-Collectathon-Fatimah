using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject collectible;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))               
        {

            OpenChest();
        }
    }

    private void OpenChest()
    {
        collectible.SetActive(true);
        Destroy(gameObject);
    }
}
