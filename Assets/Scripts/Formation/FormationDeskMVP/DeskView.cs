using System;
using System.Collections.Generic;
using UnityEngine;

public class DeskView : MonoBehaviour
{
    public event Action<CellInstance> OnClicked;
    
    private List<CellInstance> deskCells = new();
    
    public void AddDeskCells(List<CellInstance> deskCells)
    {
        this.deskCells = deskCells;
        foreach (var cell in deskCells)
        {
            cell.OnClicked += OnCellClicked;
        }
    }

    private void OnCellClicked(CellInstance cellInstance)
    {
        Debug.Log("clicked");
        OnClicked?.Invoke(cellInstance);
    }

    private void OnDestroy()
    {
        foreach (var cell in deskCells)
        {
            cell.OnClicked -= OnCellClicked;
        }
    }
}
