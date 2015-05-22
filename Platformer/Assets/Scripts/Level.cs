using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
    // dimenzije string arraya su: 40 x 19
    /*private string[] arrlevel = new string[] { "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW",
                                               "W                    C                 W",
                                               "W                                      W",
                                               "W      C                               W",
                                               "W                                      W",
                                               "W                         WWWWWW       W",
                                               "W             WWW           |          W",
                                               "W            XXXXX                     W",
                                               "W             WWW                      W",
                                               "W                                      W",
                                               "W      -   W  P                        W",
                                               "W                                   C  W",
                                               "W                                      W",
                                               "W                                      W",
                                               "W                                      W" }; 
    
    /*
     * LEGENDA:
     *      P -> Igrac ([P]layer)
     *      W -> Zid   ([W]all)
     *      X -> Stacionarna lava
     *      | -> Dropping lava 
     *      - -> Horizontalna lava (pomjerajuca)
     *      C -> Novcic ([C]oin)
     *      
     */

    private LevelStruct currentLevel;
    public static int numberOfCoins;

	// Use this for initialization
	void Start () {
        currentLevel = LevelInfo.GetLevel(LevelInfo.nextLevel);
        numberOfCoins = currentLevel.numberOfCoins;
        this.DrawLevel(currentLevel.levelarray);

        LevelInfo.nextLevel += 1; // sljedeci level
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void DrawLevel(string[] arrlevel)
    {
        for (int i = 0; i < arrlevel.Length; i ++ )
        {
            for (int j = 0; j < arrlevel[i].Length; j ++)
            {
                if (arrlevel[i][j] == 'W') {
                    /* Velicina zida se izracuna kao: startni_indeks * broj_blokova, pa se instancira jedan veliki
                     * prefab zida, umjesto vise malih, radi brzine!
                     */ 
                    int count = 0;
                    int start = j;

                    while (j < arrlevel[i].Length && arrlevel[i][j] == 'W')
                    {
                        j++;
                        count++;
                    }

                    GameObject instance = (GameObject)Instantiate(Resources.Load("Wall"), this.DajVektor3(i, start + count * 0.5f - 0.5f), new Quaternion());
                    instance.transform.localScale += new Vector3(count * 0.5f - 0.5f, 0, 0);
                    j--;
                }
                else if (arrlevel[i][j] == 'X')
                {
                    /* Instanciranje stacionarne lave radi u potpunosti kao instanciranje zida
                     */ 
                    int count = 0;
                    int start = j;

                    while (j < arrlevel[i].Length && arrlevel[i][j] == 'X')
                    {
                        j++;
                        count++;
                    }

                    GameObject instance = (GameObject)Instantiate(Resources.Load("StacionaryLava"), this.DajVektor3(i, start + count * 0.5f - 0.5f), new Quaternion());
                    instance.transform.localScale += new Vector3(count * 0.5f - 0.5f, 0, 0);
                    j--;
                }
                else if (arrlevel[i][j] == '|')
                {
                    Instantiate(Resources.Load("DroppingLava"), this.DajVektor3(i, j), new Quaternion());
                }
                else if (arrlevel[i][j] == '-')
                {
                    /* Potrebno je inicijalizirati GameObject da se uzme rotacija lave
                     * vjerovatno kad se spriteovi ubace ovo nece biti potrebno, ali za sada jeste
                     */ 
                    GameObject mvlava = Resources.Load("MovingLava") as GameObject;
                    Instantiate(mvlava, this.DajVektor3(i, j), mvlava.transform.rotation);
                }
                else if (arrlevel[i][j] == 'C')
                {
                    Instantiate(Resources.Load("Coin"), this.DajVektor3(i, j), new Quaternion());
                }
                else if (arrlevel[i][j] == 'P')
                {
                    Instantiate(Resources.Load("Player"), this.DajVektor3(i, j), new Quaternion());
                }
            }
        }
    }    

    private Vector3 DajVektor3(float i, float j) {
        float x = -10f + j / 2f; // magic numbers
        float y = 4.7f - i / 2f; 
        
        return new Vector3(x, y, 0);
    }
}
