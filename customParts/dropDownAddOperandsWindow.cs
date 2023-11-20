namespace Sci_Cal.customParts;
using System.Drawing;
public class DropDownAddOperandsWindow : Panel
{
	public List<List<DDOAButton>> DDOAButtons;
	private readonly string[] numText = new string[]{ "sqrt()",
													"cbrt()",
													"^",
													"abs()",
													"neg()",
													"fact()",
													"C", 
													"P",
													"asin()",
													"acos()",
													"atan()",
													"pi",
													"hsin()",
													"hcos()",
													"htan()",
													"()"
	};
	public EventHandler DDOAButtonClick;
	
	public DropDownAddOperandsWindow(int x, int y)
	{
		Size = new Size(410, 290);
		Location = new Point(x, y);
		BackColor = ColorTranslator.FromHtml("#5f7470");
		DDOAButtons = new List<List<DDOAButton>>();
		Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Visible = false;
		
		InitializeDDOA();
	}
	
	private void InitializeDDOA()
	{
		int buttonWidth = 90;
		int buttonHeight = 60;
		int horizontalSpacing = 10;
		int verticalSpacing = 10;

		for (int rows = 0; rows < 4; rows++)
		{
			List<DDOAButton> buttonRow = new List<DDOAButton>();
			for (int cols = 0; cols < 4; cols++)
			{
				int x = cols * (buttonWidth + horizontalSpacing) + horizontalSpacing;
				int y = rows * (buttonHeight + verticalSpacing) + verticalSpacing;

				DDOAButton but = new DDOAButton(x, y);
				but.Text = numText[rows * 4 + cols];
				SetColor(but);
				buttonRow.Add(but);
				but.Click += (sender, e) => DDOAButtonClick?.Invoke(sender, e);
				Controls.Add(but);
			}
			DDOAButtons.Add(buttonRow);
		}
	}
	private void SetColor(DDOAButton but)
	{
		switch(but.Text)
		{
			case "sqrt()":
			case "cbrt()":
			case "^":
			case "abs()":
			case "P":
			case "pi":
			case "()":
				but.BackColor = ColorTranslator.FromHtml("#778c85");
				break;
		}
	}
}

public class DDOAButton : Button
{
	public DDOAButton(int x, int y)
	{
		Size = new Size(90, 60);
		Location = new Point(x, y);
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5f7470");
		Anchor =  AnchorStyles.Top | AnchorStyles.Left;
		AutoSize = true;
		ForeColor = ColorTranslator.FromHtml("#e0e2db");
		BackColor = ColorTranslator.FromHtml("#889696");
		FlatAppearance.BorderSize = 1;
		TextAlign = ContentAlignment.MiddleCenter;
		Font = new Font("Xenara", 10);
	}
}		
