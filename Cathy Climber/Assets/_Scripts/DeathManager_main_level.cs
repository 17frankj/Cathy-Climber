using Unity.VisualScripting;
using UnityEngine;

public class DeathManager_main_level : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private Vector3 FirstCheckPointPosition;
    [SerializeField] private Vector3 SecondCheckPointPosition;
    [SerializeField] private Vector3 ThirdCheckPointPosition;

    void FixedUpdate()
    {
        SecondWorld();
        ThirdWorld();
    }

    void OnCollisionEnter(Collision collision)
    {
        NoCheckPoint();
        FirstCheckPoint();
        SecondCheckPoint();
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

    private void SecondCheckPoint()
    {
        if(CheckPoint_Manager_main_level.currentCheckpoint_main_level == 2)
        {
            player.transform.position = SecondCheckPointPosition;
        }
    }

    private void SecondWorld()
    {
        if(CheckPoint_Manager_main_level.two_active == true && player.transform.position.y < 15 )
        {
            player.transform.position = SecondCheckPointPosition;
        }
    }

    private void ThirdWorld()
    {
        if(CheckPoint_Manager_main_level.three_active == true && player.transform.position.y < 33 )
        {
            player.transform.position = ThirdCheckPointPosition;
        }
    }
}
