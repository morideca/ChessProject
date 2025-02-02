using UnityEngine;

public class FigureFormationInstance : MonoBehaviour, IDragged
{
    private Collider collider;
    public GameObject GameObject { get; private set; }
    public FigureType Type { get; private set; }

    private void Start()
    {
        collider = GetComponent<Collider>();
        GameObject = gameObject;
    }

    public void SetType(FigureType type)
    {
        Type = type;
    }
    
    public void SwitchDragging()
    {
        collider.enabled = !collider.enabled;
    }
}
