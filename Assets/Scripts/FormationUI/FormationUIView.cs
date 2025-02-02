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
    private Button pawnButton;

    private void Start()
    {
        finish.onClick.AddListener(FinishClicked);
        queenButton.onClick.AddListener(QueenClicked);
        pawnButton.onClick.AddListener(PawnClicked);
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
}

