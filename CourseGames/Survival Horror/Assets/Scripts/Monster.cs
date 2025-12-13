using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject gameOverObj;
    public GameObject gameOverUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = playerObj.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Game Over");
            gameOverObj.SetActive(true);
            gameOverUI.SetActive(true);
            
            playerObj.GetComponent<CharacterController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            
            Destroy(this.gameObject);
        }
    }
}
