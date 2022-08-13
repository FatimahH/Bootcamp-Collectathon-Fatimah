using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float fireballDamage;
    [SerializeField] private float fireballLifeSpan;
    [SerializeField] private GameObject damageEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject damage = Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(fireballDamage);
            //Destroy(collision.gameObject);
        }

        Destroy(gameObject);
        Destroy(damage, 0.5f);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(fireballLifeSpan);
        Destroy(gameObject);
    }
}
