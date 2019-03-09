using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject leftStone;
    public GameObject rightStone;
    public float xRange;

    private float spawnWait=1.0f;
    private float startWait=0.5f;
    private float waveWait=1.0f;

    private int scores;
    public Text scoreText;
    public int life;
    public Text lifeText;

    public GameObject overMenu;
    private bool gameover;
    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitRocks());
        scores = 0;
        //life = 100;
        GameOverText.text = "";
        UpdateScore();
        UpdateLife();
        overMenu.SetActive(false);
    }

    IEnumerator InitRocks()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int rockCnt = Random.Range(1, 4);
            for (int i = 0; i < rockCnt; i++)
            {
                Vector3 playerPos = player.transform.position;
                Vector3 rockPosition = new Vector3(Random.Range(-1,2)*xRange, 2.0f, playerPos.z+10.0f);
                Quaternion spawnRotation = Quaternion.identity;
                if (rockPosition.x > 0)
                {
                     //Debug.Log("left stone");
;                    Instantiate(leftStone, rockPosition, spawnRotation);
                }
                else if (rockPosition.x < 0)
                {
                    //Debug.Log("right stone");
                    Instantiate(rightStone, rockPosition, spawnRotation);
                }

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                break;
            }
        }
    }

    public void AddScore(int scorePerHit)
    {
        Debug.Log("add score");
        scores += scorePerHit;
        if (scores / 100 > 0)
        {
            scores -= 100;
            life += 20;
        }
        UpdateScore();
    }
    public void AddDamage(int damagePerHit)
    {
        Debug.Log("add damage "+damagePerHit.ToString());
        life -= damagePerHit;
        UpdateLife();

        if (life <= 0)
        {
            gameover = true;
            GameOverText.text = "再来一次吧";
            Time.timeScale = 0.0f;
            overMenu.SetActive(true);
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "能量: " + scores.ToString();
    }
    private void UpdateLife()
    {
        lifeText.text = "生命: " + life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > 280.0f)
        {
            gameover = true;
            GameOverText.text = "欢 迎 回 家";
            overMenu.SetActive(true);
        }
    }


}
