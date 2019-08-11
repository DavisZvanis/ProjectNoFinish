using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //love means happiness of someone else no matter how
    public void Act()
    {
        int dieRoll = Random.Range(0, 2);
        switch (dieRoll)
        {
            case 0:
                Defend();
                break;
            case 1:
                Spell spellToCast = GetRandomSpell();
                if (spellToCast.spellType == Spell.SpellType.Heal)
                {
                    // get friendly weak target
                }
                if (!CastSpell(spellToCast, null))
                {
                    // attack
                }
                break;
            case 2:
                // attack
                break;
        }
    }

    Spell GetRandomSpell()
    {
        return spells[Random.Range(0, spells.Count - 1)];
    }
    public override void Die()
    {
        base.Die();
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
