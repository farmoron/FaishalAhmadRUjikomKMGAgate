using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Fungsi untuk tombol Start

    public AudioSource BGM;
    public void Start()
    {
        BGM.Play();
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Fungsi untuk tombol Credit
    public void OnClickCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    // Fungsi untuk tombol Exit
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Keluar Aplikasi...");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}