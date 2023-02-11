using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TotalUIController : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject Player;
    int Level;
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI totalPointText;
    [SerializeField] TextMeshProUGUI PointText;
    [SerializeField] TextMeshPro PlayerInGameLevelText;
    [SerializeField] TextMeshProUGUI LevelText;
    [Header("Script Managers")]
    [SerializeField] Forward moveForward;
    [SerializeField] GameManager gameManager;
    [SerializeField] MovementManager movementManager;
    [SerializeField] PlayerController playerControllerScript;
    [Header("Panels")]
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject inGame;
    [SerializeField] GameObject LevelCompleted;
    [SerializeField] GameObject LevelFailed;
    [SerializeField] GameObject PlayBeforeScreen;
    [SerializeField] GameObject HomeButtons;

    public static TotalUIController instance;
    #endregion
    #region Monobehaviors
    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
        PlayBeforeScreen.SetActive(true);
        //   MainMenu.SetActive(true);
    }
    private void OnEnable()
    {
        StaticEvents.onGameStart += UIStartController;
        //   StaticEvents.onLevelCompleted += UILevelWin;
    }
    private void OnDisable()
    {
        StaticEvents.onGameStart -= UIStartController;
        //  StaticEvents.onLevelCompleted -= UILevelWin;
    }
    #endregion
    #region UI Controllers
    private void UIStartController()
    {
        PlayerInGameLevelText.gameObject.SetActive(true);
        MainMenu.SetActive(false);
        PlayBeforeScreen.SetActive(true);
        int currentLevel = PlayerPrefs.GetInt("level");
        LevelText.text = "Level: " + currentLevel;
    }
    public void UILevelWin()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        gameManager.canForward = false;
        inGame.SetActive(false);
        LevelCompleted.SetActive(true);
        //  StartCoroutine(UIWinDelay());
    }
    public void PlayBeforeScreenClose()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        PlayBeforeScreen.SetActive(false);
        inGame.SetActive(true);
        gameManager.canForward = false;
        int currentLevel = PlayerPrefs.GetInt("level");
        LevelText.text = "Level: " + currentLevel;

    }
    /*  public IEnumerator UIWinDelay()
      {
          yield return new WaitForSeconds(0.1f);

          yield return null;
      }*/
    public IEnumerator UILevelLoss()
    {
        yield return new WaitForSeconds(2);
        inGame.SetActive(false);
        LevelFailed.SetActive(true);
    }
    public void HomeButon()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        Time.timeScale = 0;
        inGame.SetActive(false);
        HomeButtons.SetActive(true);
    }
    public void ResumeButon()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        Time.timeScale = 1;
        inGame.SetActive(true);
        HomeButtons.SetActive(false);
    }

    #endregion
}

