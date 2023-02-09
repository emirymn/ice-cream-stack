using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCashText;
    public static GameManager instance;
    private int Level;
    private int UILevel;
    public bool canSwipe = false;
    public bool canForward = false;
    public float totalCash, levelTotalCash;
    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        PlayerPrefs.SetInt("LevelUI", UILevel);
        totalCash = PlayerPrefs.GetFloat("totalCash");
        UpgradeTotalCashUI();
        levelTotalCash = 0;
    }

    private void OnEnable()
    {
        //  StaticEvents.onLevelCompleted += LevelCompleted;
        StaticEvents.onObstacle += LossLevel;

    }
    private void OnDisable()
    {
        //  StaticEvents.onLevelCompleted -= LevelCompleted;
        StaticEvents.onObstacle -= LossLevel;
    }
    public void UpgradeTotalCashUI()
    {
        if (totalCash >= 1000 && totalCash < 999999)
            totalCashText.text = (totalCash / 1000).ToString("F2") + "K $";
        else if (totalCash >= 1000000)
            totalCashText.text = (totalCash / 1000000).ToString("F2") + "M $";
        else
            totalCashText.text = PlayerPrefs.GetFloat("totalCash") + " $";
    }
    public void GameStarted()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        StaticEvents.onGameStart?.Invoke();
    }
    public void LevelCompleted()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.win);
        int levelNum = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("level", levelNum + 1);
        PlayerPrefs.Save();
    }
    public void NextLevel()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.win);
        int levelNum = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("level", levelNum + 1);
        PlayerPrefs.Save();

        int defaultSceneCount = 3;
        int currentLevel = PlayerPrefs.GetInt("level");
        int sceneCount = SceneManager.sceneCountInBuildSettings - 1;

        if (sceneCount >= currentLevel)
        {
            //  SceneManager.LoadScene(currentLevel);
            SceneManager.LoadScene(Random.Range(defaultSceneCount, sceneCount));
        }
        else
        {
            SceneManager.LoadScene(Random.Range(defaultSceneCount, sceneCount));
        }
    }
    public void OnClickToRetry()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void RestartScene()
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void LossLevel()
    {
        if (StackSystem.instance.itemStack.Count == 0)
        {
         //   MainMusic.instance.gameObject.GetComponent<AudioSource>().Pause();
           AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.loss);
            canForward = false;
            canSwipe = false;
            StartCoroutine(TotalUIController.instance.UILevelLoss());
            StartCoroutine(ResumeMusic());
        }
    }
    IEnumerator ResumeMusic()
    {
        yield return new WaitForSeconds(2f);
        yield return null;
     //   MainMusic.instance.gameObject.GetComponent<AudioSource>().UnPause();
    }
}
