using System.Collections.Generic;

public class PopBackCommand : ICommand {
	private List<int> _intList;
	private int _value;
	
	public PopBackCommand(List<int> intList) {
		_intList = intList;
	}

	public void Execute() {
		_value = _intList[_intList.Count - 1];
		_intList.RemoveAt(_intList.Count - 1);
	}
	
	public void Undo() {
		_intList.Add(_value);
	}
}