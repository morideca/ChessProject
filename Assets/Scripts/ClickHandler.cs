using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{
    private Camera mainCameraControl;
    private LayerMask layerMask;
    
    private void Start()
    {
        mainCameraControl = Camera.main;
        layerMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var mousePosition = Input.mousePosition;
            Ray ray = mainCameraControl.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask))
            {
                hit.collider.gameObject.TryGetComponent<CellInstance>(out CellInstance cellInstance);
                cellInstance?.OnClick();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("FormationScene");
        }
        
    }
}
