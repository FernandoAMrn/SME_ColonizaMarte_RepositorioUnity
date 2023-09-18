using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;

public class PlacementSystem_Tut : MonoBehaviour         // SISTEMA PARA INSTANCEAR LOS EDIFICIOS
{
    [SerializeField]
    private GameObject cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    //GameObjects de prefabs de edificios
    [SerializeField]
    private GameObject dormitorios;
    [SerializeField]
    private GameObject EstacionDeAgua;
    [SerializeField]
    private GameObject EstacionDeEnergia;
    [SerializeField]
    private GameObject Invernadero;
    [SerializeField]
    private GameObject Laboratorio;
    [SerializeField]
    private GameObject Taller;

    public GameObject NotEnoughResourcesPopUp;
    public GameObject NextPanel;
    public GameObject previousPanel;
    

    [SerializeField]
    private GameObject gridVisualization;

    private void Start()
    {

        StopPlacementDormitorio();
        StopPlacementAgua();
        StopPlacementEnergia();
        StopPlacementInverandero();
        StopPlacementLaboratorio();
        StopPlacementTaller();

        
        
    }

    //Modos de Construccion
    #region
    public void StartPlacementDormitorio()
    {
        StopPlacementDormitorio();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructureDormitorios;
        inputManager.OnExit += StopPlacementDormitorio;
    }
    public void StartPlacementAgua()
    {
        StopPlacementAgua();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructureAgua;
        inputManager.OnExit += StopPlacementAgua;
    }

    public void StartPlacementEnergia()
    {
        StopPlacementEnergia();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructureEnergia;
        inputManager.OnExit += StopPlacementEnergia;
    }

    public void StartPlacementInvernadero()
    {
        StopPlacementInverandero();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructureInvernadero;
        inputManager.OnExit += StopPlacementInverandero;
    }
    public void StartPlacementLaboratorio()
    {
        StopPlacementLaboratorio();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        
        inputManager.OnClicked += PlaceStructureLaboratorio;
        
        inputManager.OnExit += StopPlacementLaboratorio;
    }

    public void StartPlacementTaller()
    {
        StopPlacementTaller();
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        
        inputManager.OnClicked += PlaceStructureTaller;
        inputManager.OnExit += StopPlacementTaller;
    }
    #endregion
    //Termina modos de Construccion

    //Instancias de estructuras
    #region
    private void PlaceStructureDormitorios()
    {
        if(inputManager.IspointerOverUI())
        {
            return;
        }

        if (GameManager_Tut.people >= 0 && GameManager_Tut.energy >= 0) //CHECA SI TIENE SUFICIENTES RECURSOS
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(dormitorios);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);
            GameManager_Tut.Instance.ExpendPeople(4); // TO DO REGRESAR RECURSO DE PERSONAS CUANDO SE ACABE LA CONSTRUCCION
            GameManager_Tut.Instance.ExpendEnergy(3);
            previousPanel.SetActive(false);

            NextPanel.SetActive(true);
        }
        
       
        
       
    }

    private void PlaceStructureAgua()
    {
        if (inputManager.IspointerOverUI())
        {
            return;
        }
        if (GameManager_Tut.people >= 0 && GameManager_Tut.energy >=0)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(EstacionDeAgua);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);
            GameManager_Tut.Instance.ExpendPeople(2);
            GameManager_Tut.Instance.ExpendEnergy(2);
            NextPanel.SetActive(true);
            previousPanel.SetActive(false);
        }
       

    }

    private void PlaceStructureEnergia()
    {
        if (inputManager.IspointerOverUI())
        {
            return;
        }
        if (GameManager_Tut.people >= 0)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(EstacionDeEnergia);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);  
            GameManager_Tut.Instance.ExpendPeople(3);
            NextPanel.SetActive(true);
            previousPanel.SetActive(false);

            // >>>>>>>>>>>AQUI CODIGO DE SFX<<<<<<<<<<<<<<<<<<
        }
       


    }

    private void PlaceStructureInvernadero()
    {
        if (inputManager.IspointerOverUI())
        {
            return;
        }
        if (GameManager_Tut.people >=0 && GameManager_Tut.energy >= 0)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(Invernadero);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);
            GameManager_Tut.Instance.ExpendPeople(3);
            GameManager_Tut.Instance.ExpendEnergy(3);
            NextPanel.SetActive(true);
            previousPanel.SetActive(false);

            // >>>>>>>>>>>AQUI CODIGO DE SFX<<<<<<<<<<<<<<<<<<
        }
        


    }

    private void PlaceStructureLaboratorio()
    {
        if (inputManager.IspointerOverUI())
        {
            return;
        }

        if (GameManager_Tut.people >=0 && GameManager_Tut.energy >= 0)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(Laboratorio);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);
            GameManager_Tut.Instance.ExpendPeople(4);
            GameManager_Tut.Instance.ExpendEnergy(4);
            NextPanel.SetActive(true);
            previousPanel.SetActive(false);

            // >>>>>>>>>>>AQUI CODIGO DE SFX<<<<<<<<<<<<<<<<<<
        }
         // ENVIA POP UP DE QUE FALTAN RECURSOS
        


    }

    private void PlaceStructureTaller()
    {
        if (inputManager.IspointerOverUI())
        {
            return;
        }
        if (GameManager_Tut.people >= 0 && GameManager_Tut.energy >=0)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject newDormitorios = Instantiate(Taller);
            newDormitorios.transform.position = grid.CellToWorld(gridPosition);
            GameManager_Tut.Instance.ExpendPeople(4);
            GameManager_Tut.Instance.ExpendEnergy(2);
            NextPanel.SetActive(true);
            previousPanel.SetActive(false);

            // >>>>>>>>>>>AQUI CODIGO DE SFX<<<<<<<<<<<<<<<<<<
        }
         // ENVIA POP UP DE QUE FALTAN RECURSOS
        

    }

    

    #endregion

    //Termina Instancias de Estructuras

    //Exit modo de construccion
    #region
    private void StopPlacementDormitorio()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructureDormitorios;
        
        inputManager.OnExit -= StopPlacementDormitorio;
    }

    private void StopPlacementAgua()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructureAgua;
        inputManager.OnExit -= StopPlacementAgua;
    }

    private void StopPlacementEnergia()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructureEnergia;
        inputManager.OnExit -= StopPlacementEnergia;
    }

    private void StopPlacementInverandero()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructureInvernadero;
        inputManager.OnExit -= StopPlacementInverandero;
    }

    private void StopPlacementLaboratorio()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        
        inputManager.OnClicked -= PlaceStructureLaboratorio;
        
        inputManager.OnExit -= StopPlacementLaboratorio;
    }

    private void StopPlacementTaller()
    {
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructureTaller;
        inputManager.OnExit -= StopPlacementTaller;
    }
#endregion
    //Termina Exit modos de construccion

    

    //UPDATE
    private void Update()
    {
       
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);

    }


}
