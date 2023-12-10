namespace Sci_Cal.customParts;

public class HistoryData
{
	private string _expression;
	private string _result;
	private DateTime _dt;
	
	public string Expression
	{
		get { return _expression; }
		set { _expression = value; }
	}
	
	public string Result
	{
		get { return _result; }
		set { _result = value; }
	}
	
	public DateTime Dt
	{
		get { return _dt; }
		set { _dt = value; }
	}
	
	public HistoryData(string expression, string result, DateTime dateTime)
	{
		Expression = expression;
		Result = result;
		Dt = dateTime;
	}
}
