using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vega.Managers
{
    public class CoroutineManager : MonoBehaviour
    {
        #region FIELDS

        public static CoroutineManager Instance;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region METHODS

        #endregion
    }
}