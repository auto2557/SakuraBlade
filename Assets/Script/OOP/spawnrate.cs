using UnityEngine;

public class spawnrate : Coin
{
    public GameObject tail;
    public GameObject horn;
    public GameObject claw;
    protected int ratedrop;
    protected int tailspawn;
    protected int partoftail;
    protected int hornspawn;
    protected int partofhorn;
    protected int clawspawn;
    protected int partofclaw;

    public Vector2 spawnArea;


    public void SpawnPartofKaiju()
    {
        if (ratedrop >= 72)
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
        else if (ratedrop >= 25)
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
        else if (ratedrop >= 90)
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
