using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private Vector3 FirstCheckPointPosition;

    void OnCollisionEnter(Collision collision)
    {
        NoCheckPoint();
        FirstCheckPoint();
    }

    private void NoCheckPoint()
    {
        if(CheckPointManager.currentCheckpoint == 0)
        {
            player.transform.position = startingPosition;
        }
    }

    private void FirstCheckPoint()
    {
        if(CheckPointManager.currentCheckpoint == 1)
        {
            player.transform.position = FirstCheckPointPosition;
        }
    }
}
