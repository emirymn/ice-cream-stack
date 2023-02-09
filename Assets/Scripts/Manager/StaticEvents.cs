using System;

public class StaticEvents
{
    public static Action NextLevel;
    public static Action UpgradePlayer;
    public static Action<int> InLevelPortal;
    // TRY
    public static Action onGameStart;
    public static Action onLevelFailed;
    public static Action onLevelEndReached;
    public static Action onLevelEndReachedFinish;
    public static Action onLevelCompleted;
    public static Action<float> onItemSelled;
    public static Action<float> onItemAddtotheStack;
    public static Action<float> onItemRemovetotheStack;
    public static Action<float> onItemValueDecreaseChange;
    public static Action<float> onItemValueIncreaseChange;
    public static Action onObstacle;
    public static Action<float> onSellItem;
}
