namespace Sci_Cal;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Sci_Cal.customParts;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public partial class View : Form
{
	private InOutField inOutField;
	private NumPad numPad;
	private AdditionalButtons additionalPad;
	private TopTopButtons topTopButtons;
	private BottomTopButtons bottomTopButtons;
	private DropDownAddOperandsWindow dropDownOperandsWindow;
	private HistoryPanel historyPanel;
	
	public EventHandler CloseView;
	public EventHandler SendExpressionToController;
	public EventHandler SwitchMode;
	private HashSet<string> longString = new HashSet<string> { "log()",
															"ln()",
															"sin()",
															"cos()",
															"tan()", 
															"sqrt()", 
															"cbrt()", 
															"asin()", 
															"acos()", 
															"atan()", 
															"hsin()",
															"hcos()", 
															"htan()",
															"abs()", 
															"neg()",
															"fact()",
															"()"
														};
    public View()
    {
        InitializeComponent();
		
		//TitleBar 100x, 50y
		TitleBar tempTitleBar = new TitleBar();
		tempTitleBar.minButton.Click += (sender, e) => {
            this.WindowState = FormWindowState.Minimized;
        };
			
		tempTitleBar.MouseDown += new MouseEventHandler(inOutField_MouseDown);
		this.Controls.Add(tempTitleBar);
		//TitleBar end
		
		//InOutField start 560x, 200y
		inOutField = new InOutField(10, 60);
		
		this.Controls.Add(inOutField);
		
		InitializeNumPad();
		InitializeSideButtons();
		InitializeTopButtons();
		InitializeHistoryPanel();
		InitializeDropDownOperators();
		SetButtonClickEvents();
		
		this.FormClosing += (sender , e) => CloseView?.Invoke(sender, e);
		
    }
	public void HistoryPanel_InitializeHistoryList(List<HistoryData> hdl)
	{
		historyPanel.InitializeHistoryList(hdl);
	}
	public List<HistoryData> HistoryPanel_ToBeSavedHistory()
	{
		return historyPanel.ToBeSavedHistory;
	}
	public string getExpressionFromInOutField()
	{
		return inOutField.getExpression();
	}
	public void UpdateOutField(string text)
	{
		inOutField.UpdateOutField(text);
	}
	public void UpdateHistoryPanel(int x, int y, HistoryData hd)
	{
		historyPanel.NewHistoryItem(x, y, hd);
		historyPanel.NewHistoryData(hd);
	}
	public void UnSubActivate()
	{
		UnSub();
	}
	public void DisposePanelsActivate()
	{
		DisposePanels();
	}
	private void InitializeDropDownOperators(){
		dropDownOperandsWindow = new DropDownAddOperandsWindow(0, topTopButtons.Bottom - 10);
		Controls.Add(dropDownOperandsWindow);
	}
	private void InitializeTopButtons()
	{
		topTopButtons = new TopTopButtons(0, 240);
		bottomTopButtons = new BottomTopButtons(0, 290);
		Controls.Add(bottomTopButtons);
		Controls.Add(topTopButtons);
	}
	private void InitializeNumPad(){
		numPad = new NumPad(0, 360);
		numPad.BackColor = ColorTranslator.FromHtml("#5f7470");
		
		Controls.Add(numPad);
	}
	private void InitializeHistoryPanel()
	{
		historyPanel = new HistoryPanel(0, topTopButtons.Bottom - 10);
		Controls.Add(historyPanel);
	}
	
	private void InitializeSideButtons(){
		additionalPad = new AdditionalButtons(300, 360);
		Controls.Add(additionalPad);
	}
	private void DisposePanels()
	{
		inOutField.Dispose();
		
		numPad.CleanUp();
		numPad.Dispose();
		
		additionalPad.CleanUp();
		additionalPad.Dispose();
		
		topTopButtons.CleanUp();
		topTopButtons.Dispose();
		
		bottomTopButtons.CleanUp();
		bottomTopButtons.Dispose();
		
		dropDownOperandsWindow.CleanUp();
		dropDownOperandsWindow.Dispose();
		
		historyPanel.CleanUp();
		historyPanel.Dispose();
	}
	private void SetButtonClickEvents(){
		numPad.NumButtonClick += SendButtonTextToInputField;
		additionalPad.OpButtonClick += SendButtonTextToInputField;
		dropDownOperandsWindow.DDOAButtonClick += SendButtonTextToInputField;
		additionalPad.DegRadSwitch += (sender, e) => SwitchMode?.Invoke(sender, e);
		additionalPad.EqualButtonClick += (sender, e) => SendExpressionToController?.Invoke(sender, e);
		bottomTopButtons.BottomTopButtonsClick += SendButtonTextToInputField;
		topTopButtons.ShowInvisField += ShowAddButtons;
		topTopButtons.DeleteChar += DelChars;
		topTopButtons.ClearField += DelChars;
		topTopButtons.GetAns += GetAns;
		topTopButtons.ShowHistory += HistoryPanelShow;
	}
	private void UnSub(){
		numPad.NumButtonClick -= SendButtonTextToInputField;
		additionalPad.OpButtonClick -= SendButtonTextToInputField;
		dropDownOperandsWindow.DDOAButtonClick -= SendButtonTextToInputField;
		additionalPad.DegRadSwitch -= (sender, e) => SwitchMode(sender, e);
		additionalPad.EqualButtonClick -= (sender, e) => SendExpressionToController(sender, e);
		bottomTopButtons.BottomTopButtonsClick -= SendButtonTextToInputField;
		topTopButtons.ShowInvisField -= ShowAddButtons;
		topTopButtons.DeleteChar -= DelChars;
		topTopButtons.ClearField -= DelChars;
		topTopButtons.GetAns -= GetAns;
		topTopButtons.ShowHistory -= HistoryPanelShow;
	}
	private void HistoryPanelShow(object sender, EventArgs e)
	{
		dropDownOperandsWindow.Visible = false;
		historyPanel.BringToFront();
		historyPanel.Visible = !historyPanel.Visible;
	}
	private void GetAns(object sender, EventArgs e)
	{
		if(historyPanel.GetListCount() > 0)
		{
			inOutField.InsertAns(historyPanel.get_ans());
		}
	}
	private void ShowAddButtons(object sender, EventArgs e)
	{
		historyPanel.Visible = false;
		dropDownOperandsWindow.BringToFront();
		dropDownOperandsWindow.Visible = !dropDownOperandsWindow.Visible;
		
	}
	private void DelChars(object sender, EventArgs e){
		if(sender is Button button){
			if(button.Text == "DEL"){
				inOutField.DelChar();
			} 
			else 
			{
				inOutField.ClearField();
			}
		}
	}
	
	private void SendButtonTextToInputField(object sender, EventArgs e)
	{
		if(sender is Button button)
		{
			string text = button.Text;
			if(longString.Contains(button.Text))
			{
				inOutField.InsertLong(text);
			}
			else
			{
				inOutField.concatenateTextFromButton(text);
			}
		}
	}
	
	[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
	private extern static void ReleaseCapture();
	
	[DllImport("user32.DLL", EntryPoint = "SendMessage")]
	private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
	
	private void inOutField_MouseDown(object sender, MouseEventArgs e){
		ReleaseCapture();
		SendMessage(this.Handle, 0x112, 0xf012, 0);
	}
	private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(510, 660);
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Text = string.Empty;
		this.ControlBox = false;
		this.BackColor = ColorTranslator.FromHtml("#5f7470");
    }
}
public class Controller
{
	public string mode = "DEG";
	public Model model;
	public View view;
	public Controller(View v, Model m)
	{
		this.view = v;
		this.model = m;
		
		view.SendExpressionToController += returnExpression;
		view.SwitchMode += Switch;
		view.CloseView += ViewClosing;
		
		List<HistoryData> history = model.ToBeSavedHistory;
		view.HistoryPanel_InitializeHistoryList(history);
	}
	private void ViewClosing(object sender, EventArgs e)
	{
		model.ActivateSave();
		view.UnSubActivate();
		view.DisposePanelsActivate();
		view.SwitchMode -= Switch;
		view.CloseView -= ViewClosing;
		view.Dispose();
	}
	private void Switch(object sender, EventArgs e){
		if(sender is Button button)
		{
			if(button.Text == "DEG")
			{
				button.Text = "RAD";
				mode = "RAD";
			}
			else
			{
				button.Text = "DEG";
				mode = "DEG";
			}
		}
	}
	
	private void returnExpression(object sender, EventArgs e)
	{
		try
		{
			string expression = view.getExpressionFromInOutField();
			bool degrad = (mode == "DEG")? false: true;
			double result = model.Evaluate(expression, degrad);
			DateTime dt = DateTime.Now;
			string res = (result.ToString().Length > 12)? ToScientificNotation(result): result.ToString();
				
			view.UpdateOutField(res);
			HistoryData hd = new HistoryData(expression, res, dt);
			view.UpdateHistoryPanel(0, 0, hd);
		}
		catch
		{
			view.UpdateOutField("Invalid Operation");
		}
		string ToScientificNotation(double number)
		{
			int exponent = (int)Math.Floor(Math.Log10(Math.Abs(number)));
			double coefficient = number / Math.Pow(10, exponent);
			string res = coefficient.ToString();
			/* for(int i = 7; i < res.Length; i++)
			{
				exponent++;
			} */

			coefficient = Math.Round(coefficient, 8);
			return $"{coefficient} * 10^{exponent}";
		}
	}
}

public class Model
{
	private static readonly HashSet<string> binaryOperators = new HashSet<string> { "+", "-", "*", "/", "^", "%", "C", "P" };
    private static readonly HashSet<string> unaryOperators = new HashSet<string> { "log", "ln", "sin", "cos", "tan", "sqrt", "cbrt", "asin", "acos", "atan", "hsin","hcos", "htan","abs", "neg", "pi", "fact"};
	private List<HistoryData> _SavedHistory;
	private List<HistoryData> _ToBeSavedHistory;
	private protected string _HistoryFilePath = "./customParts/history.json";
	public List<HistoryData> ToBeSavedHistory
	{
		get{ return _ToBeSavedHistory; }
		set{ _ToBeSavedHistory = value; }
	}
	
	public Model()
	{
		_SavedHistory = LoadHistoryFromFile();
		_ToBeSavedHistory = new List<HistoryData>();
		for(int i = 0; i < _SavedHistory.Count; i++)
		{
			HistoryData hd = new HistoryData(_SavedHistory[i].Expression, _SavedHistory[i].Result, _SavedHistory[i].Dt);
			_ToBeSavedHistory.Add(hd);
		}
	}
	public void ActivateSave()
	{
		SaveChanges();
	}
	private void SaveChanges()
	{
		_SavedHistory = null; //remove ref to original loaded list
		_SavedHistory = _ToBeSavedHistory;
		string json = JsonConvert.SerializeObject(_SavedHistory); //prep to write to JSON
		File.WriteAllText(_HistoryFilePath, json); //Overwrite JSON 
		_SavedHistory = null; //remove ref
		_ToBeSavedHistory = null; // remove ref
	}
	private List<HistoryData> LoadHistoryFromFile()
	{
		if(File.Exists(_HistoryFilePath))
		{
			string json = File.ReadAllText(_HistoryFilePath);
			return JsonConvert.DeserializeObject<List<HistoryData>>(json);
		}
		else
		{
			return new List<HistoryData>();
		}
	}

    public double Evaluate(string expression, bool mode)
    {
        List<string> tokens = Tokenize(expression);
        List<string> rpn = ConvertToRPN(tokens);
        Stack<double> nums = new Stack<double>();
		

        foreach (string token in rpn){
            if (!unaryOperators.Contains(token) && !binaryOperators.Contains(token)){
                nums.Push(double.Parse(token));
            }
            else if (binaryOperators.Contains(token)){
                double val2 = nums.Pop();
                double val1 = nums.Pop();
                nums.Push(PerformOperationBinary(token, val1, val2)); 
            }
            else if (unaryOperators.Contains(token)){
                double val = nums.Pop();
                nums.Push(PerformOperationUnary(token, val, mode)); 
            }
        }

        if (nums.Count == 1){
            return nums.Pop();
        }
        else{
            throw new ArgumentException("Invalid expression");
        }
    }

    public double PerformOperationBinary(string op, double val1, double val2)
    {
        switch (op)
        {
            case "+":
                return val1 + val2;
            case "-":
                return val1 - val2;
            case "*":
                return val1 * val2;
            case "/":
                return val1 / val2;
            case "^":
                return Math.Pow(val1, val2);
            case "%":
                return val1 % val2;
			case "C":
				double combinations = factorial(val1)/(factorial(val2) * factorial(val1 - val2));
				return (combinations > 0)? combinations: 0;
			case "P":
				return factorial(val1)/factorial(val1 - val2);
				
            default:
                return 0;
        }
    }

    public double PerformOperationUnary(string op, double val, bool mode)
    {
		
        switch (op)
        {
            case "sin":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Sin(val);
            case "cos":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Cos(val);
            case "tan":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Tan(val);
            case "log":
                return Math.Log(val, 10);
            case "ln":
                return Math.Log(val);
            case "asin":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Asin(val);
            case "acos":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Acos(val);
            case "atan":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Atan(val);
            case "hsin":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Sinh(val);
            case "hcos":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Cosh(val);
            case "htan":
				val = (mode)? val: val * (Math.PI / 180);
                return Math.Tanh(val);
            case "sqrt":
                return Math.Sqrt(val);
            case "cbrt":
                return Math.Cbrt(val);
            case "abs":
                return Math.Abs(val);
			case "neg":
				return val * -1; 
			case "fact":
				return factorial(val);
            default:
                return 0;
        }
    }

    public List<string> Tokenize(string expression)
    {
        List<string> tokens = new List<string>();
        string pattern = @"(\d+(\.\d*)?)|(\b(log|ln|sin|cos|tan|sqrt|cbrt|asin|acos|atan|hsin|hcos|htan|abs|neg|pi|fact)\b)|([+\-*/^%CP()])|(-\d+(\.\d*)?)|(\()|(\))";

        MatchCollection matches = Regex.Matches(expression, pattern);

        foreach (Match match in matches){
            tokens.Add(match.Value);
        }

        return tokens;
    }

    public List<string> ConvertToRPN(List<string> tokens){
        List<string> rpn = new List<string>();
        Stack<string> operatorStack = new Stack<string>();
		int currentIndex = 0;
        foreach (string token in tokens){
            if (double.TryParse(token, out _) || token == "pi"){
				if(token == "pi"){
					rpn.Add("3.14159265358979");
				}else {
					rpn.Add(token);
				}
            }
			else if(token == "-")
			{
				if(currentIndex == 0){
					operatorStack.Push("neg");
				} else {
					if(binaryOperators.Contains(tokens[currentIndex - 1]) || unaryOperators.Contains(tokens[currentIndex - 1]) || tokens[currentIndex - 1] == "("){
						operatorStack.Push("neg");
					}else if(double.TryParse(tokens[currentIndex - 1], out _)){
						operatorStack.Push("-");
					}else if(tokens[currentIndex - 1] == ")"){
						operatorStack.Push("-");
					}
				}
				
			}
            else if ((binaryOperators.Contains(token) || unaryOperators.Contains(token)) && token != "-")
            {
                while (operatorStack.Count > 0 && precedence(token) <= precedence(operatorStack.Peek()))
                {
                    rpn.Add(operatorStack.Pop());
                }
                operatorStack.Push(token);
            }
            else if (token == "("){
                operatorStack.Push(token);
            }
            else if (token == ")"){
                while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                {
                    rpn.Add(operatorStack.Pop());
                }
                if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                {
                    operatorStack.Pop();
                }
                else{
                    throw new ArgumentException("Mismatched parentheses");
                }
            }
			currentIndex++;
        }
        while (operatorStack.Count > 0)
        {
            rpn.Add(operatorStack.Pop());
        }

        return rpn;
    }
	public double factorial(double n)
    {
        double result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
    public int precedence(string op)
    {
        switch (op)
        {
            case "+":
            case "-":
                return 1;
            case "*":
            case "/":
			case "abs":
			
                return 2;
            case "sin":
            case "cos":
            case "tan":
            case "log":
            case "ln":
        	case "asin":
    		case "acos":
    		case "atan":
    		case "hsin":
    		case "hcos":
    		case "htan":
			case "neg":
			case "C":
			case "P":
                return 3;
            case "^":
            case "sqrt":
            case "cbrt":
                return 4;
            default:
                return 0;
        }
    }
}
