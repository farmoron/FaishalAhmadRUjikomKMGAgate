using UnityEngine;

public class Karakter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2 mousePosition;
    public GameObject BulletCircle;
    public Transform ShotNavigation;
    private float Timer = 0f;
    private int TotalShot;
    public int MaximumShot = 1;
    public AudioSource AudioShot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("lompat");
        //     jump();
        // }
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
    void TembakPeluru()
    {
        Instantiate(BulletCircle, ShotNavigation.position, ShotNavigation.rotation);
        AudioShot.Play();
    }
}
