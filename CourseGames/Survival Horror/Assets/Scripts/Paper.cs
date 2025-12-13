using System;
using Unity.VisualScripting;
using UnityEngine;

public class Paper : MonoBehaviour
{
    GameObject playerObj;
    private float distanceToPlayer;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(this.gameObject.transform.position, playerObj.transform.position);
        
        CollectPaper();
    }

    private void OnMouseOver()
    {
        if (distanceToPlayer < 4)
        {
            HUDManager.Instance.pressEObj.SetActive(true);
        }
        else
        {
            HUDManager.Instance.pressEObj.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        HUDManager.Instance.pressEObj.SetActive(false);
    }

    void CollectPaper()
    {
        if (distanceToPlayer < 4 && Input.GetKeyDown(KeyCode.E))
        {
            HUDManager.Instance.pressEObj.SetActive(false);
            HUDManager.Instance.AddPaper();
            Destroy(this.gameObject);
        }
    }
    
}
