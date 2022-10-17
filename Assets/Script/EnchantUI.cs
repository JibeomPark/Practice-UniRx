using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class EnchantUI : MonoBehaviour
{
    [SerializeField] private EventHandlerRx eventHandler;
    [SerializeField] private Text enchantLevelText;
    [SerializeField] private Text enchantProbText;

    private string equipName = "";
    private int enchantLevel;
    private float enchantProb = 10000;

    private void Awake()
    {
        equipName = "³ª¹« ¸ùµÕÀÌ";
        enchantLevel = 0;

        eventHandler.OnLevelChanged.Subscribe(level =>
        {
            enchantLevel = level;        

            enchantLevelText.text = $"+ {enchantLevel} {equipName}";
            enchantProbText.text = $"{enchantProb * Mathf.Pow(0.95f, level) / 100.0f}%";
        });
    }
    
    public void Init(string name, int enchant)
    {
        equipName = name;
        enchantLevel = enchant;
    }
}
