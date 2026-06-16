using System.Collections.Generic;

public class PushBackCommand : ICommand {
	private int _value;
	private List<int> _intList;
	
	public PushBackCommand(int value, List<int> intList) {
		_value = value;
		_intList = intList;
	}

	public void Execute() {
		_intList.Add(_value);
	}
	
	public void Undo() {
		_intList.RemoveAt(_intList.Count - 1);
	}
}