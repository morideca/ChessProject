using System;
using System.Collections.Generic;
using System.Linq;

public class FormationUIModel
{
    public event Action OnSoldFigure;

    private bool isWhite;
    private IFactory factory;
    private List<CellInstance> deskCells;
    private FormationSave formationSave;

    public FormationUIModel(IFactory factory, List<CellInstance> deskCells, FormationSave formationSave, bool isWhite)
    {
        this.isWhite = isWhite;
        this.factory = factory;
        this.deskCells = deskCells;
        this.formationSave = formationSave;
    }

    public void CreateFigure(FigureType type)
    {
        CellInstance cell = null;
        
        if (isWhite)
        { 
            cell = deskCells.FirstOrDefault(x => x.FigureGO == null);
        }
        else
        { 
            cell = deskCells.LastOrDefault(x => x.FigureGO == null);
        }
        factory.CreateFigure(type, cell, isWhite, false);
    }

    public void ReturnToMainMenu()
    {
        formationSave.SaveFormation(isWhite);
        ServiceLocator.GetInstance().SceneStateMachine.ChangeState(SceneType.mainMenu);
    }

    public void SellFigure()
    {
        OnSoldFigure?.Invoke();
    }
}
