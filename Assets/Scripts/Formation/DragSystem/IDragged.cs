using UnityEngine;

public interface IDragged
{
    public GameObject GameObject { get; }
    public void SwitchDragging();
}
