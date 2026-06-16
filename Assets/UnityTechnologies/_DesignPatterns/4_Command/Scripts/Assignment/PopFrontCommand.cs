using System.Collections.Generic;

public class PopFrontCommand : ICommand {
	private List<int> _intList;
	private int _value;
	
	public PopFrontCommand(List<int> intList) {
		_intList = intList;
	}

	public void Execute() {
		_value = _intList[0];
		_intList.RemoveAt(0);
	}
	
	public void Undo() {
		_intList.Add(_value);
		
		for (int i = _intList.Count - 1; i > 0; i--) {
			_intList[i] = _intList[i - 1];
		}
		
		_intList[0] = _value;
	}
}