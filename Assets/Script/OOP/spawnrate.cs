using UnityEngine;

public class spawnrate : Coin
{
    public GameObject tail;
    public GameObject horn;
    public GameObject claw;
    public int ratedrop;
    protected int tailspawn;
    private int partoftail;
    protected int hornspawn;
    private int partofhorn;
    protected int clawspawn;
    private int partofclaw;

    public Vector2 spawnArea;

  

    public void SpawnPartofKaiju()
    {
        if (ratedrop >= 1)
        {
            int randomspawn = tailspawn;
            for (int i = 0; i < randomspawn; i++)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
                    );

                GameObject spawnedCoin = Instantiate(tail, randomPosition, Quaternion.identity);
                Destroy(spawnedCoin, 5f);
            }
            partoftail += tailspawn;
        }
        else if (ratedrop >= 75)
        {
            int randomspawn = clawspawn;
            for (int i = 0; i < randomspawn; i++)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
                    );

                GameObject spawnedCoin = Instantiate(claw, randomPosition, Quaternion.identity);
                Destroy(spawnedCoin, 5f);
            }
            partofclaw += clawspawn;
        }
        else if (ratedrop >= 92)
        {
            int randomspawn = hornspawn;
            for (int i = 0; i < randomspawn; i++)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
                    );

                GameObject spawnedCoin = Instantiate(horn, randomPosition, Quaternion.identity);
                Destroy(spawnedCoin, 5f);
            }
           partofhorn += hornspawn;
        }


    }

   
}
