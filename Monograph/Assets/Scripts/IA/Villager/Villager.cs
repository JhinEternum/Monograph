using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : GAgent
{
    private List<string> attentionAnimations;
    private GameObject player;
    private float distanceBetweenObjects;
    private int qty = 0;
    public bool Distance => Vector3.Distance(player.transform.position, gameObject.transform.position) < 4;
    public string AttentionAnimation => attentionAnimations[Random.Range(0, attentionAnimations.Count)];

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attentionAnimations = new List<string>();
        attentionAnimations.Add("Salute");
        attentionAnimations.Add("Bow");
        attentionAnimations.Add("Greeting");
        attentionAnimations.Add("Waving");
    }

    void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("GoToPlace", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("GoToCampfire", 1, false);
        goals.Add(s2, 4);

        SubGoal s3 = new SubGoal("takeAttention", 1, false);
        goals.Add(s3, 5);

        Invoke("AttentionToPlayer", 1);
    }

    private void AttentionToPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Distance && qty <= 0)
        {
            beliefs.ModifyState("attention", 0);
            GetComponent<Animator>().SetTrigger(AttentionAnimation);
            transform.LookAt(player.transform);
            qty = 4;
        }
        
        qty--;
        Invoke("AttentionToPlayer", 1);
    }
}
