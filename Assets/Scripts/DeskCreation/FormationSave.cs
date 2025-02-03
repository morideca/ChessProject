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

    public void SaveFormation(bool isWhite)
    {
        List<FigureData> formationData = new();
        foreach (var cell in deskCells)
        {
            if (cell.FigureGO != null)
            {
                FigureData figureData = new();
                figureData.Type = cell.Type;
                figureData.Index = cell.Index;
                figureData.IsWhite = cell.IsWhite;
                if (cell.IsWhite == isWhite)
                {
                    formationData.Add(figureData);
                }
            }
        }

        if (isWhite)
        {
            serviceLocator.FormationData.WhiteData = formationData;
        }
        else
        {
            serviceLocator.FormationData.BlackData = formationData;
        }
    }

    public void ClearFormation()
    {
        ServiceLocator.GetInstance().FormationData.WhiteData.Clear();
    }

    public FormationData LoadFormation()
    {
        if (serviceLocator.FormationData.WhiteData.Count > 0 || serviceLocator.FormationData.BlackData.Count > 0)
        {
            return serviceLocator.FormationData;
        }
        else
        {
            return new FormationData();
        }
    }
}
