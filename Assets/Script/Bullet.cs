using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Kecepatan = 5.0f;
    public float WaktuPeluru = 3.0f;
    public Karakter karakter;
    // public Score score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // untuk mengatur gerak peluru
        transform.Translate(Vector3.right * Kecepatan * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ketika peluru menabrak Virus
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);      
        }
    }

}
