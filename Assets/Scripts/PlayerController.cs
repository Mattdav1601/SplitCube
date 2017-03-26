using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip dedSound;
    public AudioClip gemSound;

    public Text scoreText;
    public int scoreNum = 0;

    public GameObject black;
    public GameObject white;

    public float splitSpeed;
    public float moveSpeed;

    //Timer For Debug
    public float timer;
    public int Action;

    public float inputDirection;

    float BlackStartingX;
    float WhiteStartingY;

    bool isGameOver = false;

    private GameObject lastGem;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        BlackStartingX = black.transform.position.x;
        WhiteStartingY = white.transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateInput();
        UpdateMovement();
	}

    void UpdateInput()
    {
        //inputDirection = 0;

        if(Input.GetMouseButton(0))
        {
            inputDirection = 1;
            
        }
        else
        {
            inputDirection = -1;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetLevel();
        }

        //Debug stuff for time between actions testing
        if (Input.GetMouseButtonDown(0))
        {
            Timer();

        }
        if (Input.GetMouseButtonUp(0))
        {
            Timer();
        }

        timer += Time.deltaTime;
    }

    void UpdateMovement()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);

        white.transform.position = white.transform.position + new Vector3(splitSpeed * Time.deltaTime * inputDirection, 0, 0);
        white.transform.position = new Vector3(Mathf.Clamp(white.transform.position.x, WhiteStartingY, 99), white.transform.position.y, white.transform.position.z);

        black.transform.position = black.transform.position + new Vector3(splitSpeed * Time.deltaTime * inputDirection * -1,0, 0);
        black.transform.position = new Vector3(Mathf.Clamp(black.transform.position.x, -99, BlackStartingX), black.transform.position.y, black.transform.position.z);


    }
    

    public void Die()
    {
        isGameOver = true;
        Time.timeScale = 0;
        Debug.Log("Die");
        GetComponent<AudioSource>().PlayOneShot(dedSound);
    }

    public void ResetLevel()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Test");
    }

    public void Score(GameObject gem)
    {
        if (gem != lastGem)
        {
            GetComponent<AudioSource>().PlayOneShot(gemSound);
            ++scoreNum;
            scoreText.text = scoreNum.ToString();
            lastGem = gem;
        }
        Destroy(gem);
    }
    public void Timer()
    {
        
        
        Debug.Log(Action + ": " + timer);
        Action++;
        timer = 0;
    }
}
