using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2 mousePosition;
    public GameObject BulletCircle;
    public Transform ShotNavigation;
    private float Timer = 0f;
    private int TotalShot, Score;
    public int MaximumShot = 1;
    public float Health = 10;
    public AudioSource AudioShot, AudioEnemyTouchBase;
    public Image HealthImage;
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;
        Vector3 direction = worldMousePosition - transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        Timer += Time.deltaTime;
        if (Timer >= 1f)
        {
            Timer = 0f;
            TotalShot = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (TotalShot < MaximumShot)
            {
                TembakPeluru();
                TotalShot++;
            }
        }

        move();
    }
    public void move()
    {
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //untuk mengatur posisi
        mousePosition = new Vector2(worldMousePosition.x, transform.position.y); //kalau sesuai posisi pakai transform.position
        Vector2 minimum = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 maximum = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        mousePosition.x = Mathf.Clamp(mousePosition.x, minimum.x, maximum.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minimum.y, maximum.y);
        transform.position = mousePosition;
    }
    public void MinusHealth()
    {
        if (Health > 1)
        {
            AudioEnemyTouchBase.Play();
            Health = Health -1;
        HealthImage.fillAmount = Health/10;
        } else
        {
            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
        
    }
    public void AddScore()
    {
        Score = Score + 10;
    }
    void TembakPeluru()
    {
        Instantiate(BulletCircle, ShotNavigation.position, ShotNavigation.rotation);
        AudioShot.Play();
    }
}
