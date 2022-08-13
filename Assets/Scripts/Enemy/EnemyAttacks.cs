using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    public void Attack(float damage)
    {
        //Debug.Log("Attack");
        playerHealth.DecreaseHealth(damage);
    }
}
