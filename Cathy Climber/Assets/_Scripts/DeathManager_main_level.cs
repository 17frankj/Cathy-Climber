using UnityEngine;

public class DeathManager_main_level : MonoBehaviour
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
        if(CheckPoint_Manager_main_level.currentCheckpoint_main_level == 0)
        {
            player.transform.position = startingPosition;
        }
    }

    private void FirstCheckPoint()
    {
        if(CheckPoint_Manager_main_level.currentCheckpoint_main_level == 1)
        {
            player.transform.position = FirstCheckPointPosition;
        }
    }
}
