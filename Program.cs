namespace Sci_Cal;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
		
		Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
		
		Model model = new Model();
		View view = new View();
		
		Controller controller = new Controller(view, model);
		
        Application.Run(view);
    }    
}