using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FormationSave
{
    private List<CellInstance> deskCells;
    private ServiceLocator serviceLocator;

    public FormationSave(List<CellInstance> deskCells)
    {
        this.deskCells = deskCells;
        serviceLocator = ServiceLocator.GetInstance();
    }

    public void SaveFormation()
    {
        var fromationData = new FormationData();
        foreach (var cell in deskCells)
        {
            FigureData figureData = new();
            figureData.Type = cell.Type;
            figureData.Index = cell.Index;
            fromationData.Data.Add(figureData);
        }
        serviceLocator.FormationData = fromationData;
    }

    public void ClearFormation()
    {
        ServiceLocator.GetInstance().FormationData.Data.Clear();
    }

    public Dictionary<int, FigureType> LoadFormation()
    {
        if (serviceLocator.FormationData.Data.Count > 0)
        {
            Dictionary<int, FigureType> formation = serviceLocator.FormationData.Data
                .ToDictionary(figureData => figureData.Index, figureData => figureData.Type);
            return formation;
        }
        else
        {
            return new Dictionary<int, FigureType>();
        }
    }
}
