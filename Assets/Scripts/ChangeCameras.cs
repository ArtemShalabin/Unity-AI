using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    [SerializeField]
    private Camera worldCamera;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            worldCamera.gameObject.SetActive(false);
            playerCamera.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            playerCamera.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            TargetSpawn();
        }
    }
    private void TargetSpawn()
    {
        Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            target.position = hit.point;
        }
    }
}
