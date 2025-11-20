using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float SpawnInterval;
    public GameObject PrefabsObject;
    public bool IsSpawning=true;
    public float minX;
    public float maxX;
    public Transform SpawnPosition;
    public float StartDelay;
    void Start()
    {
        ScreenRange();
        StartCoroutine(StartSpawn());
    }
    void ScreenRange()
    {
        Camera cam = Camera.main;
        float jarakZ = Mathf.Abs(cam.transform.position.z);

        Vector3 kiri = cam.ScreenToWorldPoint(new Vector3(0, 0, jarakZ));
        Vector3 kanan = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, jarakZ));

        minX = kiri.x;
        maxX = kanan.x;
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPos = new Vector3(randomX, 5f, 0);

        int pilih = Random.Range(0, 5);
        Instantiate(PrefabsObject, spawnPos, Quaternion.identity);

            
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Base"))
        {
            col.gameObject.GetComponent<Karakter>().MinusHealth();
            Destroy(gameObject);
        }

                Destroy(gameObject);

    }
    IEnumerator SpawnObjectInterval()
    {
        while(IsSpawning)
        {
            yield return new WaitForSeconds (Random.Range(1, 5));
            SpawnEnemy();
        }
        
    }
    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds (StartDelay);
        StartCoroutine (SpawnObjectInterval());
    }
}
