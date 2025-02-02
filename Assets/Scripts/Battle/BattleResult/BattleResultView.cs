using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleResultView : MonoBehaviour
{
    public event Action OnMainMenuButtonClicked;
    
    [SerializeField] 
    private GameObject winUIPrefab;
    [SerializeField] 
    private Button mainMenuButton;
    [SerializeField] 
    private TMP_Text battleResultText;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClicked?.Invoke());
    }

    public void SwitchActive()
    {
        winUIPrefab.SetActive(!winUIPrefab.activeSelf);
    }

    public void OnWin(bool isWhite)
    {
        SwitchActive();
        if (isWhite)
        {
            battleResultText.text = "Pray White Lord, you Win!";
        }
        else
        {
            battleResultText.text = "Oh, you have lost :(";
        }
    }
}
