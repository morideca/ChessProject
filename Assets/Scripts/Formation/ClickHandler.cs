using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{
    private Camera mainCameraControl;
    private LayerMask layerMask;
    
    private void Start()
    {
        mainCameraControl = Camera.main;
        layerMask = LayerMask.GetMask("Ground", "UI");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        { 
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
            var mousePosition = Input.mousePosition;
            Ray ray = mainCameraControl.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask))
            {
                hit.collider.gameObject.TryGetComponent<IClickable>(out IClickable clickableGameObject);
                clickableGameObject?.OnClick();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("FormationScene");
        }
        
    }
}
