using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.EventSystems.EventTrigger;

public class Character : Identity
{
    public int energy;
    public int attackPoint;
    protected bool isFreeze;

    public virtual void Move(Vector2 direction)
    {
        int toX = positionX + (int)direction.x;
        int toY = positionY + (int)direction.y;
        if (HasPlacement(toX, toY))
        {
            if (IsDemonWalls(toX, toY))
            {
                mapGenerator.walls[toX, toY].Hit();
            }
            else if (IsPotion(toX, toY))
            {
                mapGenerator.potions[toX, toY].Hit();
                positionX = toX;
                positionY = toY;
                transform.position = new Vector2(positionX, positionY);

            }
            else if (IsExit(toX, toY))
            {
                mapGenerator.Exit.Hit();
                positionX = toX;
                positionY = toY;
                transform.position = new Vector2(positionX, positionY);
            }
        }
        else
        {
            positionX = toX;
            positionY = toY;
            transform.position = new Vector2(positionX, positionY);
        }
    }

    public virtual void TakeDamage(int Damage)
    {
        energy -= Damage;
        Debug.Log("Current Energy : " + energy);
        CheckDead();
    }
    public virtual void TakeDamage(int Damage, bool freeze)
    {
        energy -= Damage;
        isFreeze = freeze;
        GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("Current Energy : " + energy);
        Debug.Log("you is Freeze");
        CheckDead();
    }


    public void Heal(int healPoint)
    {
        // energy += healPoint;
        // Debug.Log("Current Energy : " + energy);
        // เราสามารถเรียกใช้ฟังก์ชัน Heal โดยกำหนดให้ Bonuse = false ได้ เพื่อที่จะให้ logic ในการ heal อยู่ที่ฟังก์ชัน Heal อันเดียวและไม่ต้องเขียนซ้ำ
        Heal(healPoint, false);
    }
    public void Heal(int healPoint, bool Bonuse)
    {
        energy += healPoint * (Bonuse ? 2 : 1);
        Debug.Log("Current Energy : " + energy);
    }


    protected virtual void CheckDead()
    {
        if (energy <= 0)
        {
            Destroy(gameObject);
        }
    }

    #region Map related methods ...

    /// <summary>
    /// HasPlacement method checks if the given position has any object or not.
    /// If there is an object or it is Walls (not walkable), it returns true, otherwise false.
    /// HasPlacement ใช้ในการตรวจสอบว่าตำแหน่งที่กำหนดมีวัตถุอะไรบ้าง ถ้ามีวัตถุหรือเป็นผนัง (ไม่สามารถเดินผ่านได้) จะคืนค่าเป็นจริง มิฉะนั้นเป็นเท็จ
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool HasPlacement(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData != mapGenerator.empty;
        //return false;
    }

    public bool IsDemonWalls(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.demonWall;
        //return false;
    }

    public bool IsPotion(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.potion;
        //return false;
    }

    public bool IsExit(int x, int y)
    {
        var mapData = mapGenerator.GetMapData(x, y);
        return mapData == mapGenerator.exit;
        //return false;
    }

    #endregion
}