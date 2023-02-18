using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    [SerializeField] GameObject mainMenu, shopMenu, aboutMenu, lvMenu, lvMenu2, lvMenu3;
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
        int currentLevel = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene((currentLevel % 3) + 3);

    }
    public void BackButton()
    {
        audioS.PlayOneShot(button2);
        DontDestroyOnLoad(audioS.gameObject);
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
        aboutMenu.SetActive(false);
        lvMenu.SetActive(false);
        lvMenu2.SetActive(false);
        lvMenu3.SetActive(false);
    }
    public void ShopOpenButton()
    {
        audioS.PlayOneShot(button3);
        DontDestroyOnLoad(audioS.gameObject);
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }
    public void UsOpenButton()
    {
        audioS.PlayOneShot(button4);
        DontDestroyOnLoad(audioS.gameObject);
        mainMenu.SetActive(false);
        aboutMenu.SetActive(true);

    }
    public void OpenLvPage1()
    {
        mainMenu.SetActive(false);
        lvMenu.SetActive(true);
        lvMenu2.SetActive(false);
        lvMenu3.SetActive(false);
    }
    public void OpenLvPage2()
    {
        lvMenu.SetActive(false);
        lvMenu2.SetActive(true);
        lvMenu3.SetActive(false);
    }
    public void OpenLvPage3()
    {
        lvMenu.SetActive(false);
        lvMenu2.SetActive(false);
        lvMenu3.SetActive(true);
    }
    public void PlayLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene((currentLevel % 3) + 3);
    }
}
