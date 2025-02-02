using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "figureConfig/figureData")]
public class FigureConfigsData : ScriptableObject
{
    public List<FigureConfig> FigureConfigs => figureConfigs;
    
    [FormerlySerializedAs("figureConfigs")] [SerializeField] 
    private List<FigureConfig> figureConfigs;
}
