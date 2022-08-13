using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && gameManager.HasCollectedAll())
        {
            SceneManager.LoadScene("Win");
        }
    }

}
