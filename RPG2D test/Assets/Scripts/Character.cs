using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int health;
    public int maxHealth;
    public int attackPower;
    public int defencePower;
    public int manaPoints;
    public List<Spell> spells;

    public void Hurt(int amount)
    {
        int damageAmount = Random.Range(0, 1) * (amount - defencePower);
        health = Mathf.Max(health - damageAmount, 0);
        if (health == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        int healAmount = Random.Range(0, 1) * (int)(amount + (maxHealth * .33));
        health = Mathf.Min(health + healAmount, maxHealth);
    }

    public void Defend()
    {
        defencePower += (int)(defencePower * .33);
        Debug.Log("Def increased");
    }

    public bool CastSpell(Spell spell, Character targetCharacter)
    {
        bool successful = manaPoints >= spell.manaCost;

        if (successful)
        {
            Spell spellToCast = Instantiate<Spell>(spell, transform.position, Quaternion.identity);
            manaPoints -= spell.manaCost;
            spellToCast.Cast(targetCharacter);
        }

        return successful;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
        Debug.LogFormat("{0} has died", characterName);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
