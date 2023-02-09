using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip button1, button2, button3, button4;
    private static MainMenuUIManager obje = null;

    void Awake()
    {
        if (obje == null)
        {
            obje = this;
        }
        else if (this != obje)
        {
            Destroy(gameObject);
        }
    }
    // Çok fazla Obje oluşturuyor bu sorun çözülecek
    public void PlayButton()
    {
        audioS.PlayOneShot(button1);
        DontDestroyOnLoad(audioS.gameObject);
        SceneManager.LoadScene("Level_2");

    }
    public void BackButton()
    {
        audioS.PlayOneShot(button2);
        DontDestroyOnLoad(audioS.gameObject);
        SceneManager.LoadScene("MainMenu");

    }
    public void ShopOpenButton()
    {
        audioS.PlayOneShot(button3);
       DontDestroyOnLoad(audioS.gameObject);
        SceneManager.LoadScene("Shop");

    }
    public void UsOpenButton()
    {
        audioS.PlayOneShot(button4);
        DontDestroyOnLoad(audioS.gameObject);
        SceneManager.LoadScene("Us");

    }
}
