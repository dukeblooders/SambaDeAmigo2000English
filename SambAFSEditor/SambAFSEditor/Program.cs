namespace SambAFSEditor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;

            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }


        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DialogBox.Error(null, e.Exception.ToString());
        }
    }
}