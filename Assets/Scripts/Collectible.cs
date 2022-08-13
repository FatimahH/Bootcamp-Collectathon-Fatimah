using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] GameManager gameManager;

    // User Inputs
    [SerializeField] float amplitude;
    [SerializeField] float frequency;

    // Position Storage Variables
    private Vector3 posOffset;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate collectibe around z axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameManager.AddCollectible();
        }
    }
}
