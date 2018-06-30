using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TapToggle : MonoBehaviour {
	[SerializeField] private Color m_VisibleColor = Color.white;
	[SerializeField] private Color m_HiddenColor = new Color(0, 0, 0, 0.2f);
	[SerializeField] private float m_Duration = 0.5f;

	private bool m_Visible;
	private DateTime m_TargetTime;
	private Color m_LastColor;
	private SpriteRenderer m_Renderer;

	private Color TargetColor { get { return m_Visible ? m_VisibleColor : m_HiddenColor; } }

	private void Start() {
		m_Renderer = GetComponent<SpriteRenderer>();
		m_LastColor = m_HiddenColor;
	}

	private void Update() {
		m_Renderer.color = DateTime.Now < m_TargetTime 
			? Color.Lerp(m_LastColor, TargetColor, 1 - (float) (m_TargetTime - DateTime.Now).TotalSeconds / m_Duration) 
			: TargetColor;
	}

	private void OnMouseUp() {
		m_Visible = !m_Visible;
		m_LastColor = m_Renderer.color;
		m_TargetTime = DateTime.Now + TimeSpan.FromSeconds(m_Duration);
	}
}