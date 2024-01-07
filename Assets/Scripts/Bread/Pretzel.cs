using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pretzel : Bread
{
    public override void OnAttack(FightType fightType)
    {
        switch (fightType)
        {
            case FightType.BasicState:
                SoundManager.Instance.OnPlayPretzelMainAttack();
                break;
            case FightType.HeavyState:
                SoundManager.Instance.OnPlayPretzelHeavyAttack();
                break;
        }
    }

    public override void OnDeath()
    {
        SoundManager.Instance.OnPlayPretzelDeath();
    }

    public override void OnHeal()
    {
        SoundManager.Instance.OnPlayPretzelHeal();
    }

    public override void SpecialPower()
    {
        if(Random.Range(0, 2) == 0)
        {
            if(breadMana <= special1Cost)
            {
                SoundManager.Instance.OnPlayPretzelSkillOne();
                Fight();
                return;
            }

            Debug.Log(name + " used twister");
            DamageFromCurrentAttack = specialAttack1Damage;
            if(GameObject.FindWithTag("Swan").TryGetComponent(out Swan swan))
                swan.IncomingDamage = DamageFromCurrentAttack;
            //trigger animation
        }
        else
        {
            if(breadMana <= special2Cost)
            {
                SoundManager.Instance.OnPlayPretzelSkillTwo();
                Fight();
                return;
            }

            Debug.Log(name + " used rain cheese");
            DamageFromCurrentAttack = specialAttack2Damage;
            if(GameObject.FindWithTag("Swan").TryGetComponent(out Swan swan))
                swan.IncomingDamage = DamageFromCurrentAttack;
            //trigger animation
        }

        Attack();
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
