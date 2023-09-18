using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCam : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1;
    }
    public Camera cam_Dormitorios;
    public Camera cam_Agua;
    public Camera cam_Energia;
    public Camera cam_Hospital;
    public Camera cam_Invernadero;
    public Camera cam_Laboratorio;
    public Camera cam_Taller;
    public Camera cam_PueroEspacial;
    public Camera cam_Rover;
    public Camera cam_Truck;


    public GameObject info_Dormitorios;
    public GameObject info_Agua;
    public GameObject info_Energia;
    public GameObject info_Hospital;
    public GameObject info_Invernadero;
    public GameObject info_Laboratorio;
    public GameObject info_Taller;
    public GameObject info_PuertoEspacial;
    public GameObject info_Rover;
    public GameObject info_Truck;

    public GameObject arrow_Droms;
    public GameObject arrow_Agua;
    public GameObject arrow_Energia;
    public GameObject arrow_Hospital;
    public GameObject arrow_Invernadero;
    public GameObject arrow_Laboratorio;
    public GameObject arrow_Taller;
    public GameObject arrow_PuertoEspcaical;
    public GameObject arrow_Rover;
    public GameObject arrow_Truck;


    public void switchCam(int x)
    {
        deactivateAll();
        if (x == 1)
        {
            cam_Dormitorios.enabled = true;
            info_Dormitorios.SetActive(true);
            arrow_Droms.SetActive(true);
        }
        else if (x == 2)
        {
            cam_Agua.enabled = true;
            info_Agua.SetActive(true);
            arrow_Agua.SetActive(true);
        }
        else if (x == 3)
        {
            cam_Energia.enabled = true;
            info_Energia.SetActive(true);
            arrow_Energia.SetActive(true);
        }
        else if (x == 4)
        {
            cam_Hospital.enabled = true;
            info_Hospital.SetActive(true);
            arrow_Hospital.SetActive(true);
        }
        else if (x == 5)
        {
            cam_Invernadero.enabled = true;
            info_Invernadero.SetActive(true);
            arrow_Invernadero.SetActive(true);
        }
        else if (x == 6)
        {
            cam_Laboratorio.enabled = true;
            info_Laboratorio.SetActive(true);
            arrow_Laboratorio.SetActive(true);
        }
        else if (x== 7)
        {
            cam_Taller.enabled = true;
            info_Taller.SetActive(true);
            arrow_Taller.SetActive(true);
        }
        else if (x == 8)
        {
            cam_PueroEspacial.enabled = true;
            info_PuertoEspacial.SetActive(true);
            arrow_PuertoEspcaical.SetActive(true);
        }
        else if (x == 9)
        {
            cam_Rover.enabled = true;
            info_Rover.SetActive(true);
            arrow_Rover.SetActive(true);
        }
        else
        {
            cam_Truck.enabled = true;
            info_Truck.SetActive(true);
            arrow_Truck.SetActive(true);
        }
    }

    private void deactivateAll()
    {
        cam_Dormitorios.enabled = false;
        cam_Agua.enabled = false;
        cam_Energia.enabled = false;
        cam_Hospital.enabled = false;
        cam_Invernadero.enabled = false;
        cam_Laboratorio.enabled = false;
        cam_Taller.enabled = false;
        cam_PueroEspacial.enabled = false;
        cam_Rover.enabled = false;
        cam_Truck.enabled = false;

        info_Dormitorios.SetActive(false);
        info_Agua.SetActive(false);
        info_Energia.SetActive(false);
        info_Hospital.SetActive(false);
        info_Invernadero.SetActive(false);
        info_Laboratorio.SetActive(false);
        info_Taller.SetActive(false);
        info_PuertoEspacial.SetActive(false);
        info_Rover.SetActive(false);
        info_Truck.SetActive(false);

        arrow_Droms.SetActive(false);
        arrow_Agua.SetActive(false);
        arrow_Energia.SetActive(false);
        arrow_Hospital.SetActive(false);
        arrow_Invernadero.SetActive(false);
        arrow_Laboratorio.SetActive(false);
        arrow_Taller.SetActive(false);
        arrow_PuertoEspcaical.SetActive(false);
        arrow_Rover.SetActive(false);
        arrow_Truck.SetActive(false);
    }
}
