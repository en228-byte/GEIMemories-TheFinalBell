using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EyeController : MonoBehaviour
{
    public int health = 5;

    [Header("Chain Enemies")]
    public GameObject nextEnemy;

    [Header("Boss Settings")]
    public bool isBoss = false;
    public UnityEvent onBossDeath;

    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        if (nextEnemy != null)
            nextEnemy.SetActive(false);
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
        if (nextEnemy != null)
            nextEnemy.SetActive(true);
        if (isBoss && onBossDeath != null)
            onBossDeath.Invoke();

        Destroy(gameObject);

        //added for gates
        SceneChanging sceneChanger = new SceneChanging();
        sceneChanger.ChangeScene("gamePlay");
        navigation.gate1 = "td";
        navigation.canMove = true;
    }
}