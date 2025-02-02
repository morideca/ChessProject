
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
        public void CreateFigure(FigureType figureType, CellInstance cell, bool isWhite, bool isBattle);
        public List<GameObject> WhiteFigures { get; }
        public List<GameObject> BlackFigures { get; }
}
