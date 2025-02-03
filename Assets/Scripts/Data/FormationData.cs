using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class FormationData
{
    public List<FigureData> WhiteData = new();
    public List<FigureData> BlackData = new();
}
