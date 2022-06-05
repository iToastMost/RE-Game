using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryScreen;
    //public GameObject InventoryFade;
    //public AudioSource InventoryOpen;
    public bool isOpen = false;
    public bool canClose = false;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && isOpen == false && canClose == false)
        {
            isOpen = true;
            //InventoryOpen.Play();
            //InventoryFade.SetActive(true);
            StartCoroutine(InvControl());
            
        }

        if (Input.GetKey(KeyCode.Tab) && isOpen == true && canClose == true)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            isOpen = false;
            //InventoryScreen.SetActive(false);
            StartCoroutine(InvControl());
        }
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        isOpen = false;
        //InventoryScreen.SetActive(false);
        StartCoroutine(InvControl());
    }
    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(0.25f);
        if (isOpen == true)
        {
            InventoryScreen.SetActive(true);
        }
        else
        {
            InventoryScreen.SetActive(false);
        }
        yield return new WaitForSeconds(0.25f);
        if (isOpen == true)
        {
            canClose = true;
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            canClose = false;
        }
           
    }
}
