using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRocket : MonoBehaviour
{
    Rigidbody playerRB;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1000.0f;
    [SerializeField] float rotationThrust = 100.0f;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] ParticleSystem mainEngineParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    // ctrl + shift + space --> string references
    void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
     void ProcessRotation(){
        if (Input.GetKey(KeyCode.A)){
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        }
    }

    void StartThrusting()
    {
        playerRB.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSound);
        }

        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }
    
    void ApplyRotation(float rotationThisFrame){
        playerRB.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        playerRB.freezeRotation = false;
    } 
}
