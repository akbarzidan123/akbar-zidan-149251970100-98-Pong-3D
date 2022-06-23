using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public GameController score;
    public BallSpawner ball;
    private void OnTriggerEnter(Collider coll) 
    {
        if(coll.CompareTag("ball"))
        {
            for(int i = 0; i < ball.ballContainer.Count; i++)
            {
                if(coll.gameObject.name == ball.ballContainer[i].name)
                {
                    Destroy(ball.ballContainer[i]);
                    ball.ballContainer.RemoveAt(i);
                }
            }
            int temp = int.Parse(""+ gameObject.name[gameObject.name.Length-1]);
            score.UpdateScore(temp);
        }
    }
    public void InActiveCollider()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
