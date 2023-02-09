using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementManager : MonoBehaviour
{
    [SerializeField] float nosIncreaseSpeed;
    [SerializeField] GameObject Player;
    Forward moveForwardScript;
    [SerializeField] GameManager gameManager;
    [SerializeField] Swipee swipe;

    private void Awake()
    {
        moveForwardScript = Player.GetComponent<Forward>();
        gameManager.canSwipe = false;
    }
    private void OnEnable()
    {
        StaticEvents.onLevelCompleted += OnFinishEnter;
        StaticEvents.onLevelEndReached += InFinishWay;
    }
    private void OnDisable()
    {

        StaticEvents.onLevelCompleted -= OnFinishEnter;
        StaticEvents.onLevelEndReached -= InFinishWay;
    }
    public void OnStart()
    {
        gameManager.canSwipe = true;
        gameManager.canForward = true;
    }
    public void OnFinishEnter()
    {
        gameManager.canForward = false;
    }
    public void InFinishWay()
    {
        gameManager.canSwipe = false;
    }
}
