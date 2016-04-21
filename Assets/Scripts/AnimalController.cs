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

           if (distance < 2f)
                attackPerson();
       
            if (isRunning || isAttacking)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 4 * Time.deltaTime);
                lookAtPlayer();
            }
            
       

            
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

    public void lookAtPlayer() {
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

    public void hitWithTranq()  {
        timesShot++;
        if (timesShot >= 3)
            switchToPassive();
        else
        {
            switchToIdle();
            StartCoroutine(setToPassiveFor10());
        }
    }

    public void attackPerson()
    {
        player.transform.position -= Vector3.back * 5f;
        StartCoroutine(setToPassiveFor10());
        switchToIdle();
        playerController.loseShot();
    }

    public void switchToIdle()
    {
        isIdle = true;       
        anim.playAutomatically = false;
        anim.Stop();
        isRunning = false;
        isAttacking = false;
    }
    
    public void switchToPassive()
    {
        isPassive = true;
        isIdle = true;
        anim.playAutomatically = false;
        anim.Stop();
        isRunning = false;
        isAttacking = false;
    }
 
    IEnumerator setToPassiveFor10() {
        isPassive = true;
        yield return new WaitForSeconds(10f);
        isPassive = false;
    }


}
