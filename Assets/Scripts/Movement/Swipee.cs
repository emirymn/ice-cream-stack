using UnityEngine;
using DG.Tweening;


public class Swipee : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [Space]
    [SerializeField] private float dragSpeed = 0.2F;
    [SerializeField] private float dragIncrementSpeed = 100;
    [SerializeField] private float maxAxisDifference = 0.2F;
    [Space]
    [SerializeField][Range(0, 10)] private float dragSensivity;
    [SerializeField][Range(0, 10)] private float inputSensivity;
    [SerializeField][Range(0, 10)] private float inputDamping;
    [SerializeField] private float dragSpeedMobile = 0.02F;
    [Space]
    [SerializeField] private float moveLimit = 2f;
    private static GameObject player_;

    private Vector2 deltaDrag;
    private Vector2 lastInputPosition;
    private bool isDragging = false;
    private float mouseX;

    private void Awake()
    {
        gameManager = GameObject.Find("------Manager").GetComponent<GameManager>();
        player_ = gameObject;
    }
    #region Mobile Controll
    private void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                mouseX = transform.position.x + dragSpeedMobile * touch.deltaPosition.x;
                mouseX = Mathf.Clamp(mouseX, -moveLimit, moveLimit);
            }
        }
    }

    private void StandaloneInput()
    {
        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButton(0))
        {
            return;
        }
        float increaseAxisValue = Mathf.Clamp(Input.GetAxis("Mouse X") * dragSpeed, -maxAxisDifference, maxAxisDifference);
        mouseX = Mathf.MoveTowards(transform.localPosition.x, transform.localPosition.x + increaseAxisValue, dragIncrementSpeed * Time.deltaTime);
        mouseX = Mathf.Clamp(mouseX, -moveLimit, moveLimit);
    }
    #endregion


    #region Monobehaviour
    private void OnEnable()
    {
        // StaticEvents.onGameStart += StartMoving;
        StaticEvents.onLevelEndReached += StopMoving;
        StaticEvents.onLevelFailed += StopMoving;
        //  StaticEvents.onLevelEndReachedFinish += StopMovingForward;
    }

    private void OnDisable()
    {
        //   StaticEvents.onGameStart -= StartMoving;
        StaticEvents.onLevelEndReached -= StopMoving;
        //  StaticEvents.onLevelFailed -= StopMoving;
        //   StaticEvents.onLevelEndReachedFinish -= StopMovingForward;
    }
    private void Update()
    {

        if (!gameManager.canSwipe) return;
        GetInput();
        mouseX += deltaDrag.x * inputSensivity * Time.deltaTime;
        mouseX = Mathf.Clamp(mouseX, -moveLimit, moveLimit);
        MovingSidewasy();
    }
    #endregion

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastInputPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            deltaDrag = Vector2.zero;
        }
        if (isDragging)
        {
            deltaDrag = (Vector2)Input.mousePosition - lastInputPosition;
            deltaDrag *= dragSensivity;

            lastInputPosition = Input.mousePosition;
        }
    }

    protected void MovingSidewasy()
    {
        Vector3 pos = transform.localPosition;
        pos.x = mouseX;

        transform.localPosition = Vector3.Lerp(transform.localPosition,
            new Vector3(mouseX, pos.y, pos.z), inputDamping);
    }
    private void StopMoving()
    {

        gameManager.canSwipe = false;
        player_.transform.DOMoveX(0, 1.5f);
        // Vector3 localPos = transform.localPosition;
        // localPos.x = 0;
        //  transform.localPosition = localPos;
    }

}
