using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FormationUIView : MonoBehaviour
{
    public event Action OnFinishClicked;
    public event Action OnSellClicked;
    public event Action<FigureType> OnFigureButtonClicked;
    
    [SerializeField] 
    private Button sell;
    [SerializeField] 
    private Button finish;
    [SerializeField] 
    private Button queenButton;
    [SerializeField] 
    private Button warriorButton;

    private void Start()
    {
        sell.onClick.AddListener(() => OnSellClicked?.Invoke());
        finish.onClick.AddListener(() => OnFinishClicked?.Invoke());
        queenButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.mage));
        warriorButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.warrior));
    }
}

