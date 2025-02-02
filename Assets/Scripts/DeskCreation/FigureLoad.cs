using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureLoad
{
    private readonly List<CellInstance> deskCells;
    private readonly IFactory factory;
    private readonly FormationSave formationSave;
    
    private  Dictionary<int, FigureType> whiteFigures;
    private  Dictionary<int, FigureType> blackFigures;
    
    public FigureLoad(FormationSave formationSave, IFactory factory, 
        List<CellInstance> deskCells, Dictionary<int, FigureType> blackFigures)
    {
        this.formationSave = formationSave;
        this.deskCells = deskCells;
        this.factory = factory;
        this.blackFigures = blackFigures;
        LoadFormation();
    }

    public void LoadFigures(bool isBattle)
    {
        whiteFigures = formationSave.LoadFormation();
        foreach (var (index, value) in whiteFigures)
        {
            var cell = deskCells[index];
            factory.CreateFigure(value, cell, true, isBattle);
        }

        if (isBattle)
        {
            foreach (var (index, value) in blackFigures)
            {
                var cell = deskCells[index];
                factory.CreateFigure(value, cell, false, isBattle);
            }
        }
    }
    
    private void LoadFormation()
    {
        whiteFigures?.Clear();
        whiteFigures = formationSave.LoadFormation();
    }
}
