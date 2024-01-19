using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{

        public static CheckWinner instance;
    private void Awake()
    {
        instance = this; 
    }
    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothSpeed = 1.0f;

    public Transform PlayerRotation;


    // Start is called before the first frame update
    void Start()
    {
        defaultCamera.enabled = true;
        winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner) {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }


    private void LateUpdate()
    {
        if (target != null && isWinner) {
            Vector3 desiredPoiston = new Vector3(target.position.x+5.4f, target.position.y +2, target.position.z);
            Vector3 smoothedPostion = Vector3.Lerp(winnerCamera.transform.position, desiredPoiston, smoothSpeed * Time.deltaTime);

            winnerCamera.transform.position = smoothedPostion;

            PlayerRotation.LookAt(new Vector3(winnerCamera.transform.position.x, PlayerRotation.position.y,PlayerRotation.position.z));

        }
    }

    private void OnTriggerStay(Collider other)
    {
        print("check");
        if (other.CompareTag("Player") && PlayerContro.instance.groundedPlayer) { 
        isWinner = true;
        }
    }

}
