using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    public GameObject playerMovement;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip succesSound;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;
    AudioSource audioSource;
    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start(){
        audioSource =  GetComponent<AudioSource>();
    
    }

    void Update(){
        RespondToDebugKeys(); // disabled this or refinite if you want to publish it
    }

    void RespondToDebugKeys(){
        if (Input.GetKeyDown(KeyCode.L)){
            LoadNextLevel();
        }

         else if (Input.GetKeyDown(KeyCode.C)){
            collisionDisabled = !collisionDisabled;// toggle collision
        }
    }
   private void OnCollisionEnter(Collision other) {

    if (isTransitioning || collisionDisabled) { return; }

    switch(other.gameObject.tag){
        case "Friendly":
            Debug.Log("friend");
            break;

        case "Finish":     
            StartSuccesSequence();
            break;

        case "Fuel":
            Debug.Log("You picked up fuel");
            break;

        default:
            //Debug.Log("sorry you explode!!!");
            StartCrashSequence();
            break;
    }
   }

   void StartCrashSequence(){
    // to do add sfx upon crash
    // todo add paeticle effect upon crash
    isTransitioning = true;
    audioSource.Stop();
    crashParticle.Play();
    audioSource.PlayOneShot(crashSound);
    GetComponent<PlayerControllerRocket>().enabled = false;
    Invoke("ReloadLevel", levelLoadDelay);
   }

   void StartSuccesSequence(){
    // to do add sfx upon succes
    // todo add paeticle effect upon succes
    isTransitioning = true;
    audioSource.Stop();
    successParticle.Play();
    audioSource.PlayOneShot(succesSound);
    GetComponent<PlayerControllerRocket>().enabled = false;
    Invoke("LoadNextLevel", levelLoadDelay);
   }

   void ReloadLevel(){
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //SceneManager.LoadScene("Sandbox");
    SceneManager.LoadScene(currentSceneIndex);
   }

   void LoadNextLevel(){
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
        nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
   }
}
