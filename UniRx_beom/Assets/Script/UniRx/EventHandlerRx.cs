using UnityEngine;
using UniRx;
using System;
using Random = UnityEngine.Random;


public class EventHandlerRx : MonoBehaviour
{
    private Subject<int> enchantLevelSubject = new Subject<int>();

    private int currentEnchantLevel = 0;
    private int successProb = 10000;

    public IObservable<int> OnLevelChanged => enchantLevelSubject;

    public void OnEnchantButtonClick()
    {
        int result = Random.Range(1, 10000 + 1);

        if (successProb <= 50)
            successProb = 50;

        if (result <= successProb)
        {
            currentEnchantLevel++;
            successProb = (int)(successProb * 0.95f);
            Debug.Log($"��� : ��ȭ ����! Ȯ�� : {successProb}  ��÷ : {result}");
        }
        else
        {
            Debug.Log($"��� : ��ȭ ����!! Ȯ�� : {successProb}  ��÷ : {result}");
        }

        enchantLevelSubject.OnNext(currentEnchantLevel);
    }
}
