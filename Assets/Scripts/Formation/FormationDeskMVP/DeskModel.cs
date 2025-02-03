using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeskModel
{
    private readonly FigureDrag figureDrag; 

    private IDragged draggedFigure;
    private IDragged newDraggedFigure;
    
    public DeskModel(FigureDrag figureDrag)
    {
        this.figureDrag = figureDrag;
    }

    public void OnCellClicked(CellInstance cellInstance)
    {
        if (cellInstance.FigureGO != null)
        {
            figureDrag.DragFigure(cellInstance);
        }
        else
        {
            figureDrag.ReleaseFigure(cellInstance);
        }
    }
}
