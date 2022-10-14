using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

namespace Interfaces
{

    public interface IEnemy
    {

        public EnemyType Type { get; }
        public float originSpeed { get; set; }
        public float currentSpeed { get; set; }
        public bool isDie { get; set; }

    }

}