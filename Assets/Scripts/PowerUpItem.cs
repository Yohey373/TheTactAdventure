using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemBase
{
    
    public int upperLevel = 1;

    private void Start()
    {
        // itemFunction�ɏ�����ݒ肷��
        itemFunctionHandler += LevelUpItemFunction;
    }

    public void LevelUpItemFunction(CharacterParameterBase characterParameterBase)
    {
        characterParameterBase.LevelUp(upperLevel);
        this.gameObject.SetActive(false);
    }
}
