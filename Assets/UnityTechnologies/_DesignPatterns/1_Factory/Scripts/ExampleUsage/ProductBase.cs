using DesignPatterns.Factory;
using UnityEngine;

public abstract class ProductBase : MonoBehaviour, IProduct {
	public abstract string ProductName { get; set; }
	public abstract void Initialize();
} 