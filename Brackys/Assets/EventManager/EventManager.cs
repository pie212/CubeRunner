
using UnityEngine;
using UnityEngine.Events;
public static class EventManager 
{
    public static event UnityAction UpdateUI;
    public static void OnUpdateUI() => UpdateUI?.Invoke();

    public static event UnityAction UpdateMoneyUI;
    public static void OnUpdateMoneyUI() => UpdateMoneyUI?.Invoke();
}
