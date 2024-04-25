using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private float ofset;
    [SerializeField]
    private Transform hunter;
    private bool isGame = true;
    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGame == true)
        {
            agent.SetDestination(target.position);

        }
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGame = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
            isGame = false;
        }
    }
}
