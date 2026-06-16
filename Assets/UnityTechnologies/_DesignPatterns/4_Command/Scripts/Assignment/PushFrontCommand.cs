using System.Collections.Generic;

public class PushFrontCommand : ICommand {
	
	private int _value;
	private List<int> _intList;
	
	public PushFrontCommand(int value, List<int> intList) {
		_value = value;
		_intList = intList;
	}

	public void Execute() {
		_intList.Add(_value);
		
		for (int i = _intList.Count - 1; i > 0; i--) {
			_intList[i] = _intList[i - 1];
		}
		
		_intList[0] = _value;
	}
	
	public void Undo() {
		_intList.RemoveAt(0);
	}
}