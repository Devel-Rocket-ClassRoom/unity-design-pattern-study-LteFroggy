using System.Collections.Generic;
using DesignPatterns.Observer;
using UnityEngine;

// 버튼이 눌리면, 버튼 눌린 횟수를 콘솔에 찍는다.
public class ClickedCounterObserver : MonoBehaviour {
	[SerializeField] private ButtonSubject[] _buttonSubject;
	private readonly Dictionary<ButtonSubject, int> _buttonPressedTimes = new Dictionary<ButtonSubject, int>(); 

	private void Awake() {
		foreach (var subject in _buttonSubject) {
			subject.ClickedCount += OnButtonPressed;	
		}
	}
	private void OnDestroy() {
		foreach (var subject in _buttonSubject) {
			subject.ClickedCount -= OnButtonPressed;	
		}
	}

	private void OnButtonPressed(ButtonSubject buttonSubject) {
		_buttonPressedTimes.TryAdd(buttonSubject, 0);

		Debug.Log($"{buttonSubject.gameObject.name} 버튼이 총 {++_buttonPressedTimes[buttonSubject]}회 눌렸습니다! ");
	}
}