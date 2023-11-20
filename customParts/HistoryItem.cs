namespace Sci_Cal.customParts;
using System.Drawing;

public class HistoryItem : Panel
{
	private readonly Label Expression;
	private readonly Label Result;
	private readonly Label DT;
	private string ex;
	private string res;
	private string dt;
	private string test = "bruh istfg if you don't work";
	
	public HistoryItem(int x, int y, string expression, string result, DateTime dateTime)
	{
		Size = new Size(480, 150);
		Location = new Point(x, y);
		ex = expression;
		res = result;
		dt = dateTime.ToString();
		Expression = new Label();
		Expression.Text = "Expression: " + expression;

		Expression.Font = new Font("Xenara", 12);
		Expression.Location = new Point(10, 30);
		Expression.Size = new Size(480, 30);
		Controls.Add(Expression);
		
		Result = new Label();
		Result.Text = "Result: " + res;
		Result.Location = new Point(Expression.Left, Expression.Bottom + 10);
		Result.Size = new Size(480, 30);
		Result.Font = new Font("Xenara", 12);
		Controls.Add(Result);
		
		DT = new Label();
		DT.Text = "DateTime : " + dt;
		DT.Location = new Point(Result.Left, Result.Bottom + 10);
		DT.Size = new Size(480, 30);
		DT.Font = new Font("Xenara", 12);
		Controls.Add(DT);
	}
	public string getResult()
	{
		return res;
	}
}
