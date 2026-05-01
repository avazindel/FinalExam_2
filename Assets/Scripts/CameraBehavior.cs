using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Transform _player;



    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _player.position.y)
        {
            transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);

        }
    }
}
