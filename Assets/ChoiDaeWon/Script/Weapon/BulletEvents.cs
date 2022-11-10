using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

public class BulletEvents : MonoBehaviour
{

    #region È­¿°Åº

    [SerializeField] private float[] fireDotDamage;
    [SerializeField] private float[] fireDotDamageDuration;
    private float currentFireDuration;
    private bool isDotDeal;
    private IEnumerator fireDotDamageCO;

    #endregion

    #region Ice
    [Range(0f, 1f)][SerializeField] private float[] freezPower;
    [SerializeField] private float[] freezDuration;
    private bool isIce;
    #endregion

    #region God

    [SerializeField] private float[] godExtraDamage;

    #endregion

    #region poison

    [SerializeField] private float[] poisonDotDamage;
    [SerializeField] private float[] poisonDotDamageDuration;
    private float currentPoisonDuration;
    private bool isPoisonDotDeal;

    #endregion

    #region ¹ø°³

    [SerializeField] private float[] LiDuration;

    #endregion

    public void FireBullet(Enemy enemy)
    {

        currentFireDuration += fireDotDamageDuration[Upgrader.instance.FindUpGradeCount(BulletType.Fire)];
        
        if(enemy.isDebuff == false)
        {

            StartCoroutine(FireDotDamage(Upgrader.instance.FindUpGradeCount(BulletType.Fire), enemy));

        }

    }

    public void Ice(Enemy enemy) 
    {

        if(enemy.isDebuff == false)
        {
            
            StartCoroutine(ThawCo(enemy, Upgrader.instance.FindUpGradeCount(BulletType.Ice)));

        }
        
    }

    public void God(Enemy enemy)
    {

        if(enemy.Type == EnemyType.Ghost) enemy.TakeAttack(godExtraDamage[Upgrader.instance.FindUpGradeCount(BulletType.God)]);

    }

    public void Posion(Enemy enemy)
    {

        currentPoisonDuration += poisonDotDamageDuration[Upgrader.instance.FindUpGradeCount(BulletType.Poison)];

        if (enemy.isDebuff == false)
        {

            StartCoroutine(PoisonDotDamage(Upgrader.instance.FindUpGradeCount(BulletType.Poison), enemy));

        }

    }

    public void Li(Enemy enemy)
    {

        StartCoroutine(LiCo(Upgrader.instance.FindUpGradeCount(BulletType.Lightning), enemy));

    }

    IEnumerator PoisonDotDamage(int upgradeCount, Enemy enemy)
    {

        yield return null;

        while (currentPoisonDuration > 0)
        {

            enemy.TakeAttack(poisonDotDamage[upgradeCount]);
            yield return new WaitForSeconds(0.3f);
            currentPoisonDuration -= 0.3f;

        }

        currentPoisonDuration = 0;


    }
    IEnumerator ThawCo(Enemy enemy, int upgradeCount)
    {

        enemy.currentSpeed = enemy.currentSpeed - (enemy.currentSpeed * freezPower[upgradeCount]);
        yield return new WaitForSeconds(freezDuration[upgradeCount]);
        enemy.currentSpeed = enemy.originSpeed;

    }
    IEnumerator FireDotDamage(int upgradeCount, Enemy enemy)
    {

        yield return null;

        while(currentFireDuration > 0)
        {

            enemy.TakeAttack(fireDotDamage[upgradeCount]);
            yield return new WaitForSeconds(0.3f);
            currentFireDuration -= 0.3f;

        }
        
        currentFireDuration = 0;

    }
    IEnumerator LiCo(int uc, Enemy enemy)
    {

        yield return null;
        enemy.currentSpeed = 0;
        yield return new WaitForSeconds(LiDuration[uc]);
        enemy.currentSpeed = enemy.originSpeed;

    }
}
