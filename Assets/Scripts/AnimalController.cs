using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {

	public int pictureScore;

	public bool isPassive;

	public bool isIdle = true;
    public bool isRunning = false;
    public bool isAttacking = false;

    public int timesShot = 0;

	public PlayerController playerController;
	public TakePicture takePicture;

    private float distance;
    public GameObject player;

    public Animation anim;
	
	// Update is called once per frame
	void Update () {

        if (!isPassive) {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 16f)
                switchToRunning();

            if (distance < 4f)
                switchToPounce();



            if (isRunning || isAttacking)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 4 * Time.deltaTime);
                lookAtPlayer();
            }
            
       

            if (timesShot >= 3)
                isPassive = true;
        }
       
    }

	public void SetGazedAt(bool gazedAt) {
		takePicture.animalInShot = gazedAt;
		takePicture.animalName = gazedAt ? name : null;
	}

    public void switchToRunning() {
        isIdle = false;
        // Change animation state first
        anim.clip = anim["ContinueRunning"].clip;
        anim["ContinueRunning"].speed = 2;
        anim["ContinueRunning"].wrapMode = WrapMode.Loop;
        anim.playAutomatically = true;
        anim.Play("ContinueRunning");
        isRunning = true;
        isAttacking = false;
    }

    public void lookAtPlayer()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        float step = 2 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    public void switchToPounce() {
        isRunning = false;
        isAttacking = true;
        isIdle = false;
    }
}
