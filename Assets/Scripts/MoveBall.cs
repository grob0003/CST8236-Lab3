using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    Vector3 direction;

    public Rigidbody rb;
    public AudioSource sound;
    public ParticleSystem pSys;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
   
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        direction = new Vector3(hor, 0.0f, ver); 
        rb.AddForce(direction * movementSpeed); 

    }



    void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.name != "Floor" && collision.gameObject.name != "Top")
        {
           Instantiate(pSys, gameObject.transform.position, Quaternion.identity);
            sound.Play();

        }


    }
}
