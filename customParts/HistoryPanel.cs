namespace Sci_Cal.customParts;

public class HistoryPanel : Panel
{
	private Panel historyPane;
	private List<HistoryItem> list;
	private List<HistoryData> _ToBeSavedHistory;
	private Label empty;
	public List<HistoryData> ToBeSavedHistory
	{
		get{ return _ToBeSavedHistory; }
		set{ _ToBeSavedHistory = value; }
	}
	
	public HistoryPanel(int x, int y)
	{
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
	public void CleanUp()
	{
		for(int i = 0; i < list.Count; i++)
		{
			list[i].Dispose();
		}
		list = null;
	}
	public void InitializeHistoryList(List<HistoryData> hdl)
	{
		_ToBeSavedHistory = hdl;
		list = new List<HistoryItem>();
		for(int i = 0; i < hdl.Count; i++)
		{
			NewHistoryItem(0, 0, hdl[i]);
		}
	}
	public void NewHistoryData(HistoryData historyData)
	{
		_ToBeSavedHistory.Insert(0, historyData);
	}
	public void NewHistoryItem(int x, int y, HistoryData historyData)
	{
		HistoryItem log = new HistoryItem(x, y, historyData);
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
		return list[0].ResultText;
	}
	public int GetListCount()
	{
		return list.Count;
	}
}