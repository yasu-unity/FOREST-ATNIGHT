using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
    public GameObject content;

    private Vector2 movePoint;
    private bool IsOpened;
    private bool IsActive;

    private SpriteRenderer sr;
    private BoxCollider2D[]m_Colliders;
    private CircleCollider2D playerCollider;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player!=null)
           playerCollider=player.GetComponent<CircleCollider2D>();

           sr=GetComponent<SpriteRenderer>();

           m_Colliders=GetComponentsInChildren<BoxCollider2D>();

           content=Instantiate(content);
           content.transform.position=transform.position;
           content.gameObject.SetActive(false);

           IsOpened=false;
           IsActive=true;

           movePoint=(Vector2)transform.position+new Vector2(0.0f,1.2f);
    }

    private void Update()
    {
        if(IsOpened && IsActive)
        {
            content.transform.position=
              Vector2.Lerp(content.transform.position,movePoint,0.35f);
              sr.color= Color.Lerp(sr.color,Color.gray,0.4f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(m_Colliders[1].IsTouching(playerCollider)
           && col.gameObject.CompareTag("Player"))
           {
            content.gameObject.SetActive(true);
            IsOpened=true;
            StartCoroutine(WaitSwitchOff());
           }
    }
    private IEnumerator WaitSwitchOff()
    {
        yield return new WaitForSeconds(1.0f);
        IsActive=false;
    }
}
