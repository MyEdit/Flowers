using System.Windows.Forms;

namespace Flowers
{
    public partial class MainForm : Form
    {
        int UserID;
        public MainForm(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
    }
}
