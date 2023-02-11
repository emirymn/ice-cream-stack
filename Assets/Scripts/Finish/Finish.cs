using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] GameObject player, otherGo, cash;
    [SerializeField] Transform targetPos, cashPos;
    [SerializeField] List<GameObject> cashList;
    [SerializeField] private ParticleSystem confettiVFX, finishConfettiONE, finishConfettiTWO, finishConfettiTHREE, finishConfettiFOUR;
    //------------------
    int levelCoin;
    int totalCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected") || other.gameObject.CompareTag("Player"))
        {
            otherGo = other.gameObject;
            StaticEvents.onLevelCompleted?.Invoke();
        }
    }
    private void OnEnable()
    {
        StaticEvents.onLevelCompleted += OnFinish;
    }
    private void OnDisable()
    {
        StaticEvents.onLevelCompleted -= OnFinish;
    }
    void OnFinish()
    {
        StartCoroutine(InFinish());
    }

    IEnumerator InFinish()
    {
        if (otherGo.gameObject.GetComponent<ItemValue>() != null)
            StaticEvents.onSellItem?.Invoke(otherGo.gameObject.GetComponent<ItemValue>().itemValue);
        otherGo = null;
        int timer = (int)((int)GameManager.instance.levelTotalCash / 35);
        GameObject temp = Instantiate(cash, cashPos.position = new Vector3(cashPos.position.x, cashPos.position.y + 0.25f, cashPos.position.z),
                cashPos.rotation = Quaternion.Euler(90f, 90f, 0));
        cashList.Add(temp);
        CameraFollower.instance.targetto = cashList[cashList.Count - 1].transform;
        yield return new WaitForSeconds(1f);
        Debug.Log(timer);
        for (int i = 0; i < timer - 1; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject cashGo = Instantiate(cash, cashPos.position = new Vector3(cashPos.position.x, cashPos.position.y + 0.25f, cashPos.position.z),
                cashPos.rotation = Quaternion.Euler(90f, 90f, 0));
                cashList.Add(cashGo);
               yield return new WaitForSeconds(0.005f);
              //  yield return null;
                CameraFollower.instance.targetto = cashList[cashList.Count - 1].transform;
                Debug.Log(j);
            }
            AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.sell);
        }
        for (int i = 0; i < 3; i++)
        {
            TotalUIController.instance.UILevelWin();
            AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.win);
            confettiVFX.Play();
            finishConfettiONE.Play();
            finishConfettiTWO.Play();
            finishConfettiTHREE.Play();
        }
    }
}
