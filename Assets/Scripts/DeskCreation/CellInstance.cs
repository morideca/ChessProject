using System;
using UnityEngine;

public class CellInstance : MonoBehaviour, IClickable
{
    public event Action<CellInstance> OnClicked;
    
    public int Index { get; private set; }
    public GameObject FigureGO { get; private set; }
    public FigureType Type { get; private set; }
    public bool IsWhite { get; private set; }

    public void OnClick()
    {
        OnClicked?.Invoke(this);
    }

    public void SetIndex(int index)
    {
        Index = index;
    }

    public void SetFigure(bool isWhite, GameObject figure = null)
    {
        FigureGO = figure;
        IsWhite = isWhite;
        if (figure == null)
        {
            Type = FigureType.none;
        }
        else
        {
            var figureInstance = figure.GetComponent<FigureFormationInstance>();
            if (figureInstance == null)
            {
               var figureBattleInstance = figure.GetComponent<FigureBattleInstance>();
               Type = figureBattleInstance.FigureType;
            }
            else
            {
                Type = figureInstance.Type;
            }
        }
    }
}
