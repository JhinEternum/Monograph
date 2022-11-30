using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject affectionBarPrefab;
    [SerializeField] private GameObject affectionBarSpawn;
    private GameObject affectionBarInstance;
    private NavMeshAgent agent;
    private Animator animator;
    private GameObject player;
    private bool showAffectionBar;
    private bool isShowingAffectionBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        showAffectionBar = Vector3.Distance(player.transform.position, gameObject.transform.position) < 6;

        if (showAffectionBar && !isShowingAffectionBar)
        {
            affectionBarInstance = Instantiate(affectionBarPrefab, affectionBarSpawn.transform.position, Quaternion.identity);
            affectionBarInstance.transform.SetParent(affectionBarSpawn.transform);
            isShowingAffectionBar = true;
        }
        else if (!showAffectionBar && isShowingAffectionBar)
        {
            Destroy(affectionBarInstance);
        }
    }

    private void LateUpdate()
    {
        if (agent == null) return;

        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;

        animator.SetFloat("FreeLookSpeed", Mathf.Clamp(speed, 0, 0.5f));
    }
}
