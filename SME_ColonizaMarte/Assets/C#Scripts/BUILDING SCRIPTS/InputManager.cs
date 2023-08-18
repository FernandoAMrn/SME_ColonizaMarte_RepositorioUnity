using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour    // INTERPRETA LA POSICION DEL MOUSE COMO PUNTO EN EL GRID
{
    //GRID FIELDS
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 lastPosition;

    [SerializeField]
    private LayerMask placementLayerMask;
    //End GRID FIELDS

    //Prefabs fields
    public event Action OnClicked, OnExit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke(); //Aqui puedo codear para activar desde boton

        if (Input.GetKeyDown(KeyCode.Escape))
            OnExit?.Invoke(); //Aqui puedo codear para activar desde boton
    }

    public bool IspointerOverUI()
    => EventSystem.current.IsPointerOverGameObject();


    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }

    public void TerminaModoConstruccion()
    {
        OnExit?.Invoke();
    }
}
