using UnityEngine;

public class check_3 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        CheckPoint_Manager_main_level.three_active = true;
    }
}
