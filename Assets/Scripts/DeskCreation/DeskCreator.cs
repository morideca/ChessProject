using System.Collections.Generic;
using UnityEngine;

public class DeskCreator 
{
    private readonly GameObject cell;
    private readonly int deskSize;
    private readonly Transform parentParent;
    private readonly Vector3 deskPosition;
    
    private float cellWidth;
    private Vector3 firstCellPosition;

    private readonly DeskView deskView;

    public List<CellInstance> DeskCells { get; private set; } = new();
    
    public DeskCreator(Vector3 deskPosition, GameObject cell, int deskSize, Transform deskParent, DeskView deskView = null)
    {
        this.deskView = deskView;
        this.cell = cell;
        this.deskSize = deskSize;
        this.deskPosition = deskPosition;
        parentParent = deskParent;
    }
   
    public List<CellInstance> CreateDesk()
    {
        GetCellWidth();
        bool isWhite = false;
        Color color = Color.black;
        FindFirstCellPosition();
        int index = 0;
        for (int x = 0; x < deskSize; x++)
        {
            SwitchColor();
            for (int z = 0; z < deskSize; z++)
            {
                var cellPosition = firstCellPosition + new Vector3(cellWidth * x, 0, -cellWidth * z);
                var cellGO = Object.Instantiate(cell, cellPosition , Quaternion.identity, parentParent);
                cellGO.GetComponent<MeshRenderer>().material.color = color;
                var cellInstance = cellGO.AddComponent<CellInstance>();
                cellInstance.SetIndex(index);
                DeskCells.Add(cellInstance);
                SwitchColor();
                index++;
            }
        }
        
        if (deskView != null)
        {
            deskView.AddDeskCells(DeskCells);
        }

        void SwitchColor()
        {
            if (!isWhite)
            {
                color = Color.white;
            }
            else
            {
                color = Color.black;
            }
            isWhite = !isWhite;
        }

        return DeskCells;
    }

    private void GetCellWidth()
    {
        cellWidth = cell.GetComponent<MeshRenderer>().bounds.size.x;
    }

    private void FindFirstCellPosition()
    {
        var x = cellWidth * deskSize / 2; 
        firstCellPosition = new Vector3(deskPosition.x - x + cellWidth / 2, deskPosition.y, deskPosition.z + x - cellWidth / 2);
    }
}
