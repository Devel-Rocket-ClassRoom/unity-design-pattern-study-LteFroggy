using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntListManager : MonoBehaviour
{
	[Header("테스트 설정")]
	[SerializeField] private int numberToAdd = 10;
	
	private int _multiplier = 1;

	private List<int> intList = new List<int>();
	private CommandInvoker invoker = new CommandInvoker();

	private void Start()
	{
		Debug.Log("=== 커맨드 패턴 Undo/Redo 연습 시작 ===");
		PrintList();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.W))
		{
			ExecutePushBack();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.S))
		{
			ExecutePushFront();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.D))
		{
			ExecutePopBack();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Z))
		{
			ExecutePopFront();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.X))
		{
			ExecuteUndo();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.X))
		{
			ExecuteRedo();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.X))
		{
			PrintList();
		}
	}

	/// <summary>
	/// PushBackCommand를 만들고, invoker에서 실행시키기. 
	/// </summary>
	private void ExecutePushBack() {
		PushBackCommand command = new PushBackCommand(_multiplier++ * numberToAdd, intList);
		
		invoker.ExecuteCommand(command);
		Debug.Log("<color=olive>Push Back</color>");
		PrintList();
	}
	
	private void ExecutePushFront() {
		PushFrontCommand command = new PushFrontCommand(_multiplier++ * numberToAdd, intList);
		invoker.ExecuteCommand(command);
		Debug.Log("<color=olive>Push Front</color>");
		PrintList();
	}

	/// <summary>
	/// PopBackCommand를 만들고, invoker에서 실행시키기. 
	/// </summary>
	private void ExecutePopBack() {
		if (intList.Count == 0) {
			Debug.LogWarning($"<color=red>리스트 내 숫자의 갯수가 0개입니다.</color>");
			return;
		}
		
		PopBackCommand command = new PopBackCommand(intList);
		
		invoker.ExecuteCommand(command);
		Debug.Log("<color=yellow>Pop Back</color>");
		PrintList();
	}
	
	private void ExecutePopFront() {
		if (intList.Count == 0) {
			Debug.LogWarning($"<color=red>리스트 내 숫자의 갯수가 0개입니다.</color>");
			return;
		}
		
		PopFrontCommand command = new PopFrontCommand(intList);
		
		invoker.ExecuteCommand(command);
		Debug.Log("<color=yellow>Pop Front</color>");
		PrintList();
	}

	private void ExecuteUndo()
	{
		if (invoker.CanUndo())
		{
			invoker.Undo();
			Debug.Log("<color=cyan>Undo</color>");
			PrintList();
		}
		else
		{
			Debug.LogWarning("<color=red>Undo할 명령이 없습니다!</color>");
		}
	}

	private void ExecuteRedo()
	{
		if (invoker.CanRedo())
		{
			invoker.Redo();
			Debug.Log("<color=magenta>Redo</color>");
			PrintList();
		}
		else
		{
			Debug.LogWarning("<color=red>Redo할 명령이 없습니다!</color>");
		}
	}

	private void PrintList()
	{
		Debug.Log($"현재 리스트: [{string.Join(", ", intList)}] (개수: {intList.Count})");
	}
}