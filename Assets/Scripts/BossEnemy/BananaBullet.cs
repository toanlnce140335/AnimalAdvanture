using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    public void Shoot(Vector2 targetVec)
    {
        float rotZ = Mathf.Atan2(targetVec.y, targetVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        DestroyImmediate(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var h = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(h, .5f);
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
