using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public ItemData result;
    public List<MaterialRequirement> materials;
}

