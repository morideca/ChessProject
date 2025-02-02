using System;
using UnityEngine;
using UnityEngine.UI;

public class FormationUIView : MonoBehaviour
{
    public event Action OnFinishClicked;
    public event Action<FigureType> OnFigureButtonClicked;
    
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
    private Button bishopButton;
    [SerializeField] 
    private Button pawnButton;

    private void Start()
    {
        finish.onClick.AddListener(FinishClicked);
        queenButton.onClick.AddListener(QueenClicked);
        pawnButton.onClick.AddListener(PawnClicked);
        kingButton.onClick.AddListener(KingClicked);
        knightButton.onClick.AddListener(KnightClicked);
        rookButton.onClick.AddListener(RookClicked);
        bishopButton.onClick.AddListener(BishopClicked);
    }

    private void FinishClicked()
    {
        OnFinishClicked?.Invoke();
    }

    private void QueenClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.queen);
    }

    private void PawnClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.pawn);
    }

    private void KingClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.king);
    }

    private void BishopClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.bishop);
    }

    private void KnightClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.knight);
    }

    private void RookClicked()
    {
        OnFigureButtonClicked?.Invoke(FigureType.rook);
    }
}

