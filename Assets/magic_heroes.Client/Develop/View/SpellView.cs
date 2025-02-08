using System;
using UnityEngine;
using UnityEngine.UI;

namespace magic_heroes.Client.Develop.View
{
    public class SpellView : MonoBehaviour
    {
        public int id { get; private set; }

        public void Construct(int _id, Sprite _icon)
        {
            id = _id;
            GetComponentInChildren<Image>().sprite = _icon;
        }

    }
}