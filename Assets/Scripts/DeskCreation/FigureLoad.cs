using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureLoad
{
    private readonly List<CellInstance> deskCells;
    private readonly IFactory factory;
    private readonly FormationSave formationSave;
    
    private  List<FigureData> WhiteFigures;
    private  List<FigureData> BlackFigures;
    
    public FigureLoad(FormationSave formationSave, IFactory factory, 
        List<CellInstance> deskCells)
    {
        this.formationSave = formationSave;
        this.deskCells = deskCells;
        this.factory = factory;
        LoadFormation();
    }

    public void LoadFigures(bool isBattle, bool isWhite)
    {
        if (isBattle || isWhite)
        {
            WhiteFigures = formationSave.LoadFormation().WhiteData;
            foreach (var figure in WhiteFigures)
            {
                if (!figure.IsWhite) continue;
                var cell = deskCells[figure.Index];
                factory.CreateFigure(figure.Type, cell, figure.IsWhite, isBattle);
            }
        }
        
        if (isBattle || !isWhite)
        {
            BlackFigures = formationSave.LoadFormation().BlackData;
            foreach (var figure in BlackFigures)
            {
                if (figure.IsWhite) continue;
                var cell = deskCells[figure.Index];
                factory.CreateFigure(figure.Type, cell, figure.IsWhite, isBattle);
            }
        }
    }

    private void LoadFormation()
    {
        WhiteFigures?.Clear();
        WhiteFigures = formationSave.LoadFormation().WhiteData;
        BlackFigures?.Clear();
        BlackFigures = formationSave.LoadFormation().BlackData;
    }
}
