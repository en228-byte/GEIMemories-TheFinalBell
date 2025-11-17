using UnityEngine;
using System.Collections;

public class EyeController : MonoBehaviour
{
    public int health = 5; // 5 hits before it dies
    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(HitFlash());

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator HitFlash()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);

        //added for gates
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("gamePlay");
        navigation.gate1 = "h";
        navigation.canMove = true;
    }
}