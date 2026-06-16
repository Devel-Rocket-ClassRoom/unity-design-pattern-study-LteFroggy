using DesignPatterns.Factory;
using UnityEngine;

public class ProductC : ProductBase {
	
	private MeshRenderer m_MeshRenderer;
	
	public override string ProductName {
		get => gameObject.name;
		set => gameObject.name = value;
	}
	
	public override void Initialize() {
		// 시작 시에 랜덤하게 색을 바꾸면 됨.
		m_MeshRenderer = GetComponent<MeshRenderer>();
		
		m_MeshRenderer.material.color = Random.ColorHSV();
	}
}