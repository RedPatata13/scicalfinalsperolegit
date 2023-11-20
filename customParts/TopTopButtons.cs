namespace Sci_Cal;

public class TopTopButtons : Panel
{
	public List<TTButtons> buttons;
	private readonly string[] TopTopButtonsText = new string[]{ "...", "History", "ans", "DEL", "AC"};
	public EventHandler DeleteChar;
	public EventHandler ClearField;
	public EventHandler ShowInvisField;
	public EventHandler GetAns;
	public EventHandler ShowHistory;
	
	public TopTopButtons(int x, int y){
		Size = new Size (550, 60);
		Location = new Point(x, y);
		
		BackColor = ColorTranslator.FromHtml("#5F7470");
		Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		
		InitializeTopTopButtons();
	}
	
	private void InitializeTopTopButtons()
	{
		int buttonWidth = 90;
		int buttonHeight = 60;
		int horizontalSpacing = 10;
		int verticalSpacing = 10;
		buttons = new List<TTButtons>();
		
		for(int i = 0; i < 5; i++)
		{
			int x = i * (buttonWidth + horizontalSpacing) + horizontalSpacing;
			TTButtons but = new TTButtons(x, 10);
			but.Text = TopTopButtonsText[i];
			SetRole(but);
			Controls.Add(but);
			buttons.Add(but);
		}
	}
	private void SetRole(TTButtons but)
	{
		switch(but.Text)
		{
			case "DEL":
				but.Click += (sender, e) => DeleteChar?.Invoke(sender, e);
				break;
			case "AC":
				but.Click += (sender, e) => ClearField?.Invoke(sender, e);
				break;
			case "...":
				but.Click += (sender, e) => ShowInvisField?.Invoke(sender, e);
				break;
			case "History":
				but.Click += (sender, e) => ShowHistory?.Invoke(sender, e);
				break;
			case "ans":
				but.Click += (sender, e) => GetAns?.Invoke(sender, e);
				break;
		}
	}
}

public class TTButtons : Button
{
	public TTButtons(int x, int y)
	{
		Size = new Size(90, 40);
		Location = new Point(x, y);
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
		Anchor =  AnchorStyles.Top | AnchorStyles.Left;
		AutoSize = true;
		ForeColor = ColorTranslator.FromHtml("#e0e2db");
		BackColor = ColorTranslator.FromHtml("#607870");
		FlatAppearance.BorderSize = 1;
		TextAlign = ContentAlignment.MiddleCenter;
		Font = new Font("Xenara", 10);
	}
}
