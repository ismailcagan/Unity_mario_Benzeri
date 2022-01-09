using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // zararı alacak script
    [SerializeField] int maxHealth = 3;
    [SerializeField] int currentHealth = 0;

    public bool IsDead => currentHealth < 1;
    public event System.Action<int> OnHealtChanged;
    public event System.Action OnDead;
    //public int MaxHealth => maxHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        OnHealtChanged?.Invoke(currentHealth);
    }
    public void TakeHit(Damage damage)
    {
        if (IsDead) return;
        currentHealth -= damage.HitDamage;
        OnHealtChanged?.Invoke(currentHealth); // boş değilse Invoke olsun

        // ölme durumunda panel
        if (IsDead)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHealtChanged?.Invoke(currentHealth);
        }
    }
}
