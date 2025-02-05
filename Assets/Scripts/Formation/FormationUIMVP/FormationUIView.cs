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
    private Button kingButton;
    [SerializeField] 
    private Button knightButton;
    [SerializeField] 
    private Button rookButton;
    [SerializeField] 
    private Button warriorButton;
    [SerializeField] 
    private Button pawnButton;

    private void Start()
    {
        sell.onClick.AddListener(() => OnSellClicked?.Invoke());
        finish.onClick.AddListener(() => OnFinishClicked?.Invoke());
        queenButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.queen));
        pawnButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.pawn));
        kingButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.king));
        knightButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.knight));
        rookButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.rook));
        warriorButton.onClick.AddListener(() => OnFigureButtonClicked?.Invoke(FigureType.warrior));
    }
}

