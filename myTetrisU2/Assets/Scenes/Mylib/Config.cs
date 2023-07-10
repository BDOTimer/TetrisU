using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : ScriptableObject
{
    void Start()
    {
        
    }
}

/// Game.ConfigBase.GRIDSIZE
namespace Game
{
    public class ConfigBase
    {
        public ConfigBase() { }
        public ConfigBase(float a, float b, float c,
                          int   x, int   y, int   z) 
        {
            SIZECUBIC     = a;
            SIZECUBICAURA = b;
            GRIDSIZE      = c;

            KOR_X = x;
            KOR_Y = y;
            KOR_Z = z;
        }

        ///----------------------------------|
        /// Размеры Элемента(кубика).        |
        ///----------------------------------:
        public float SIZECUBIC     = 1.0f;
        public float SIZECUBICAURA = 0.1f;
        public float GRIDSIZE      = 1.0f;

        ///----------------------------------|
        /// Размеры Корзины.                 |
        ///----------------------------------:
        public int KOR_X = 6 ;
        public int KOR_Y = 12;
        public int KOR_Z = 2 ;
    }

    public class ConfigManager//ConfigManager.GetConfig()
    {
        ///----------------------------------|
        /// Вариант конфига.                 |
        ///----------------------------------:
        public static int variant = 0;
        public static ConfigBase GetConfig()
        {   
            if(null == arr)
            {
                arr = new ConfigBase[]
                {     new ConfigBase(),
                      new ConfigBase( /*CUBIC  :*/  1, 0.1f, 1,
                                      /*KORZINA:*/ 12,    6, 2)
                };
            }
            
            if    (0 > variant || variant >= arr.Length) variant = 0;
            return arr[variant];
        }

        private static ConfigBase[] arr;
    }

    public class xConfigTest
    {
        public xConfigTest() { }

        ///----------------------------------|
        /// Размеры Элемента(кубика).        |
        ///----------------------------------:
        public const float SIZECUBIC     = 1.0f;
        public const float SIZECUBICAURA = 0.2f;
        public const float GRIDSIZE      = 1.0f;

        ///----------------------------------|
        /// Размеры Корзины.                 |
        ///----------------------------------:
        public const int KOR_X = 6 ;
        public const int KOR_Y = 12;
        public const int KOR_Z = 2 ;
    }
}

