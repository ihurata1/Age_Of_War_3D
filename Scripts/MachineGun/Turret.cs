using UnityEngine;
public class Turret : MonoBehaviour {

    private Transform targetTransform;
    private GameObject target;
    public int price;
    
    [Header("Attributes")]

    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float attackDamage=20f;
    public float bulletSpeed=7f;


    [Header("Unity Setup Fields")]

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    EnemyDetecter enemyDetecter;

	// Use this for initialization
	void Start () {
        enemyDetecter=GetComponent<EnemyDetecter>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	void UpdateTarget()
    {
        target=enemyDetecter.target;
    } 
	// Update is called once per frame
	void Update () {
        if (target == null || target.tag=="EnemyBuilding")
            return;
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
	}
    void Shoot()
    {
        //Vector3 dir = target.transform.position - partToRotate.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //partToRotate.rotation = Quaternion.Euler(0f,lookRotation.y,0f);

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, target.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet!=null)
        {
            bullet.Seek(target,attackDamage,bulletSpeed);
        }
    }
}
