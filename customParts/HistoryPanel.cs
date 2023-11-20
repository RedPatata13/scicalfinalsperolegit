namespace Sci_Cal.customParts;

public class HistoryPanel : UserControl
{
	private Panel historyPane;
	private List<HistoryItem> list;
	private Label empty;
	
	public HistoryPanel(int x, int y)
	{
		list = new List<HistoryItem>();
		
		this.Size = new System.Drawing.Size(510, 350);
		this.Location = new System.Drawing.Point(x, y);
		BackColor = ColorTranslator.FromHtml("#5f7470");
		Visible = false;
		
		historyPane = new Panel();
		historyPane.Dock = DockStyle.Fill;
		historyPane.BackColor = ColorTranslator.FromHtml("#5F7470");
        historyPane.ForeColor = ColorTranslator.FromHtml("#e0e2db");
		Label historyLabel = new Label();
		historyPane.AutoScroll = true;
		
		empty = new Label();
		empty.Location = new Point(0, 0);
		empty.Size = new Size(this.Width, this.Height);
		empty.TextAlign = ContentAlignment.MiddleCenter;
		empty.Text = "History Empty";
		empty.Font = new Font("Xenara", 16);
		empty.Visible = true;
		historyPane.Controls.Add(empty);
		
		this.Controls.Add(historyPane);
	}
	public void newHistoryItem(int x, int y, string expression, string result, DateTime current)
	{
		HistoryItem log = new HistoryItem(x, y, expression, result, current);
		list.Insert(0, log);
		empty.Visible = false;
		if(list.Count % 2 == 1){
			log.BackColor = ColorTranslator.FromHtml("#607870");
		}
		

		historyPane.Controls.Add(log);
		for(int i = 1; i < list.Count; i++)
		{
			list[i].Top += log.Height + 1;
		}
	}
	public string get_ans()
	{
		return list[0].getResult();
	}
	public int GetListCount()
	{
		return list.Count;
	}
}