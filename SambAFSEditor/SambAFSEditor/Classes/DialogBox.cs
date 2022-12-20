namespace SambAFSEditor
{
    internal class DialogBox
    {
        public static void Error(IWin32Window? parent, string message)
        {
            MessageBox.Show(parent, message, nameof(SambAFSEditor), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static DialogResult Question(IWin32Window? parent, string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(parent, message, nameof(SambAFSEditor), buttons, MessageBoxIcon.Question);
        }
    }
}
