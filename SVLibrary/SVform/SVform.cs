using System.Windows.Forms;
namespace SVLibrary.SVform
{
    public partial class SVform
    {
        public static void MessageBox(object text, object caption = default, MessageBoxButtons buttons = default, MessageBoxIcon icon = default, MessageBoxDefaultButton defaultButton = default, MessageBoxOptions options = default, bool desplayHelpButton = false)
        {
            
            System.Windows.Forms.MessageBox.Show(text.ToString(), caption != null ? caption.ToString() : "", buttons, icon, defaultButton, options, desplayHelpButton);
        }
        public static void MessageBoxArray(object[] text, object caption = default, MessageBoxButtons buttons = default, MessageBoxIcon icon = default, MessageBoxDefaultButton defaultButton = default, MessageBoxOptions options = default, bool desplayHelpButton = false)
        {
            string temp = "";
            for (int i = 0; i < text.Length; i++)
                temp = temp + "item[" + i + "] => " + text[i] + "\n";
            System.Windows.Forms.MessageBox.Show(temp.ToString(), caption != null ? caption.ToString() : "", buttons, icon, defaultButton, options, desplayHelpButton);
        }
    }
}
