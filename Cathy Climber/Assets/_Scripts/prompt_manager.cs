using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class prompt_manager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        FirstMessage();
    }

    public void FirstMessage()
    {
        if(player.CompareTag("Player"))
        {
            Canvas.transform.GetChild(0).gameObject.SetActive(false); // turn off first tutorial message
        }
    }
}
