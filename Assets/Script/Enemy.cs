using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Karakter karakter;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //karakter.AddScore();
            Destroy(gameObject);
            Debug.Log("EnemyHit");
        }
        if (collision.gameObject.CompareTag("Base"))
        {
            
            Destroy(gameObject);
            Debug.Log("EnemyBreakThrough");
        }

    }
}
