using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public int maxHits;
    BoxCollider boxCollider;
    [SerializeField] ParticleSystem enemyDeathEffect;
    [SerializeField] ParticleSystem enemyHitEffect;


    [SerializeField] AudioClip deathFX;

    Camera camera;
    EnemyMover em;
    
  
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        em = GetComponent<EnemyMover>();
        camera = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
   

    void AddBoxCollider()
    {

        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(15f, 14f, 13f);

        boxCollider.isTrigger = false;

    }

    void OnParticleCollision(GameObject other)
    {

        maxHits--;
        
        enemyHitEffect.Play();
        

        if (maxHits <= 0)
        {
            KillEnemy(enemyDeathEffect);
            
        }

    }

   public void KillEnemy(ParticleSystem ps)
    {
        
        ParticleSystem deathEffect = Instantiate(ps, this.transform.position, Quaternion.identity);
        deathEffect.Play();
        AudioSource.PlayClipAtPoint(deathFX, camera.transform.position, 1.0f);

        Destroy(deathEffect);
        Destroy(gameObject);


       
    }

}
