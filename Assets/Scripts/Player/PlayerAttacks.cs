using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform fireballPosition;
    [SerializeField] private float fireballSpeed;
    public void FireballAttack()
    {
        GameObject ball =Instantiate(fireball, fireballPosition.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireballPosition.forward * fireballSpeed);
    }
}
