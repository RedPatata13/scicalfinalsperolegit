namespace Sci_Cal.customParts;
using System.Drawing;

public class HistoryItem : Panel
{
	private string _ex;
	private string _res;
	private string _dt;
	
	public string ExpressionText 
	{
		get{ return _ex; }
		set{ _ex = value; }
	}
	public string ResultText
	{
		get{ return _res; }
		set{ _res = value; }
	}
	public string DateTimeText
	{
		get{ return _dt; }
		set{ _dt = value; }
	}
	
	public HistoryItem(int x, int y, HistoryData historyData)
	{
		ExpressionText = historyData.Expression;
		ResultText = historyData.Result;
		DateTimeText = historyData.Dt.ToString();
		
		Size = new Size(480, 150);
		Location = new Point(x, y);

		Label Expression = new Label();
		Expression.Text = "Expression: " + ExpressionText;
		Expression.Font = new Font("Xenara", 12);
		Expression.Location = new Point(10, 30);
		Expression.Size = new Size(480, 30);
		Controls.Add(Expression);
		
		Label Result = new Label();
		Result.Text = "Result: " + ResultText;
		Result.Location = new Point(Expression.Left, Expression.Bottom + 10);
		Result.Size = new Size(480, 30);
		Result.Font = new Font("Xenara", 12);
		Controls.Add(Result);
		
		Label DT = new Label();
		DT.Text = "DateTime : " + DateTimeText;
		DT.Location = new Point(Result.Left, Result.Bottom + 10);
		DT.Size = new Size(480, 30);
		DT.Font = new Font("Xenara", 12);
		Controls.Add(DT);
	}
	/* class HistoryItemButton : Button 
	{
		public HistoryItemButton(int x, int y)
		{
			Size = new Size(80, 30);
			Text = "Remove";
			Location = new Point(x, y);
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
			ForeColor = ColorTranslator.FromHtml("#e0e2db");
			BackColor = ColorTranslator.FromHtml("#889696");
			FlatAppearance.BorderSize = 1;
			TextAlign = ContentAlignment.MiddleCenter;
			Font = new Font("Xenara", 8);
			Click += (sender, e) => removeLog?.Invoke(sender,e)
		}
	}
	public void UpdateButtonColor(string color)
	{
		_removeLog.BackColor = ColorTranslator.FromHtml(color);
	} */
}
