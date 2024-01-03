
using UnityEngine;
using UnityEngine.Events;
public static class EventManager 
{
    public static event UnityAction UpdateUI;
    public static void OnUpdateUI() => UpdateUI?.Invoke();

    public static event UnityAction UpdateMoneyUI;
    public static void OnUpdateMoneyUI() => UpdateMoneyUI?.Invoke();



    public static event UnityAction UpdateShopUI;
    public static void OnUpdateShopUI() => UpdateShopUI?.Invoke();


    public static event UnityAction UpdateABLUI;
    public static void OnUpdateABLUI() => UpdateABLUI?.Invoke();

    public static event UnityAction EagleEye;
    public static void OnEagleEye() => EagleEye?.Invoke();

    public static event UnityAction EagleEyeEnd;
    public static void OnEagleEyeEnd() => EagleEyeEnd?.Invoke();

    
}
