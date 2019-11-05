using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharStatus : MonoBehaviour
{
    // Enumerador (Constantes).
    public enum Class
    {
        Rookie, Mage, Warrior, Thief, Berserker
    }

    [SerializeField]
    private Class charClass = new Class();

    // Nome do Personagem.
    [SerializeField]
    private string m_name;

    // Saúde, armadura, força, agilidade, destreza, resistencia, sorte.
    [SerializeField]
    [Range(0, 100)]
    private int m_health, m_armor, m_strength, m_agility, m_dexterity, m_endurance, m_luck;

    // Personagem está vivo?
    [SerializeField]
    private bool m_isAlive = true;

    // Level do personagem, XP do personagem, level do jogador, XP do jogador.
    //public int m_charLevel, m_charXp, m_playerLevel, m_playerXp;

    // Construtor da classe.
    public CharStatus(
        Class charclass, string name, int health, int armor, int strength, int agility,
         int dexterity, int endurance, int luck)
    {
        charClass = charclass;
        m_name = name;
        m_health = health;
        m_armor = armor;
        m_strength = strength;
        m_agility = agility;
        m_dexterity = dexterity;
        m_endurance = endurance;
        m_luck = luck;
        m_isAlive = true;
    }

    // Propriedades (Acessadores).
    public string Name { get { return m_name; } set { m_name = value; } }
    public int Health { get { return m_health; } set { m_health = value; } }
    public int Armor { get { return m_armor; } set { m_armor = value; } }
    public int Strength { get { return m_strength; } set { m_strength = value; } }
    public int Agility { get { return m_agility; } set { m_agility = value; } }
    public int Dexterity { get { return m_dexterity; } set { m_dexterity = value; } }
    public int Endurance { get { return m_endurance; } set { m_endurance = value; } }
    public int Luck { get { return m_luck; } set { m_luck = value; } }
    public bool IsAlive { get { return m_isAlive; } set { m_isAlive = value; } }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    // Metodos da classe!
    public void Attack(CharStatus isAttacked)
    {
        if (isAttacked.IsAlive)
        {
            Debug.Log(Name + " is attacking " + isAttacked.Name + "!");
            Debug.Log(isAttacked.Name + " health is " + isAttacked.Health + "!");

            // Attack (força - (armadura + resistência))
            int damage = Strength - (isAttacked.Armor + isAttacked.Endurance);

            // Se dano for menor ou igual a zero, não causa dano.
            damage = damage <= 0 ? 0 : damage;

            // Deduz do personagem atacado o dano calculado.
            isAttacked.Health -= damage;

            Debug.Log(isAttacked.Name + " received " + damage + " of damage!");
            Debug.Log(isAttacked.Name + " health now is " + isAttacked.Health + "!");

            // Verifica se o personagem morreu.
            IsDead(isAttacked);

            Debug.Log("");
        }
    }

    // Attack (força - (armadura + resistência))
    public int AttackParams(int strength, int armor, int endurance)
    {
        Debug.Log(Name + " is attacking!");

        int calc = strength - (armor + endurance);

        calc = calc <= 0 ? 0 : calc;

        Debug.Log(Name + " caused " + calc + " of damage!");

        return calc;
    }

    // Verifica se esse personagem está sem saúde.
    public void IsDead(CharStatus isAttacked)
    {
        if (isAttacked.Health <= 0)
        {
            isAttacked.Health = 0;
            isAttacked.IsAlive = false;

            Debug.Log("Personagem " + isAttacked.Name + " morreu!");
        }
    }
}
