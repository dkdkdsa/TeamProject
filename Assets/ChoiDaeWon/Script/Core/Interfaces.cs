using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{

    public interface IEnemy
    {

        public float originSpeed { get; set; }
        public float currentSpeed { get; set; }
        public bool isDie { get; set; }

    }

}