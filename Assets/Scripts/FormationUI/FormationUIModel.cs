using System;
using System.Collections.Generic;
using System.Linq;

public class FormationUIModel
{
    public event Action OnSoldFigure;
    
    private IFactory factory;
    private List<CellInstance> deskCells;
    private FormationSave formationSave;

    public FormationUIModel(IFactory factory, List<CellInstance> deskCells, FormationSave formationSave)
    {
        this.factory = factory;
        this.deskCells = deskCells;
        this.formationSave = formationSave;
    }

    public void CreateFigure(FigureType type)
    {
        var cell = deskCells.FirstOrDefault(x => x.FigureGO == null); 
        factory.CreateFigure(type, cell, true, false);
    }

    public void ReturnToMainMenu()
    {
        formationSave.SaveFormation();
        ServiceLocator.GetInstance().SceneStateMachine.ChangeState(SceneType.mainMenu);
    }

    public void SellFigure()
    {
        OnSoldFigure?.Invoke();
    }
}
