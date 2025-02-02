using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FormationUIModel
{
    private IFactory factory;
    private List<CellInstance> deskCells;

    public FormationUIModel(IFactory factory, List<CellInstance> deskCells)
    {
        this.factory = factory;
        this.deskCells = deskCells;
    }

    public void CreateFigure(FigureType type)
    {
        var cell = deskCells.FirstOrDefault(x => x.FigureGO == null); 
        factory.CreateFigure(type, cell, true, false);
    }

    public void ReturnToMainMenu()
    {
        ServiceLocator.GetInstance().SceneStateMachine.ChangeState(SceneType.mainMenu);
    }
}
