using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float steerSpeed;
    [SerializeField] public float slowSpeed;
    [SerializeField] public float boostSpeed;
    [SerializeField] public float timeDestroy;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);    SpriteRenderer spriteRenderer;    bool hasPackage = false;
   
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        //tai sao ko dung duoc transform.position
        transform.Translate(0, moveAmount, 0);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        Debug.Log("slow");
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "speed up")
        {
            moveSpeed = boostSpeed;
            Debug.Log("up");
        }
        //chi dc nhan moi lan 1 goi hang dc nhan dk khi cai tag do la package va chua co goi hang
        if(other.tag == "Package" && hasPackage == false) //or !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, timeDestroy);
        }
        //has package o day nghia la da dung moi lam 
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            // da vc xong tui hang bang false de ko lay dc tui hang nua
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
     
}
