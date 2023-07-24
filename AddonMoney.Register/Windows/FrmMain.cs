namespace AddonMoney.Register.Windows
{
    public partial class FrmMain : Form
    {
        public static string ReferLinkRoot { get; private set; } = string.Empty;
        public static string ReferLinkFirst { get; set; } = string.Empty;
        public static string ReferLinkSecond { get; set; } = string.Empty;
        public static bool OnlyRootLink { get; private set; } = false;

        public FrmMain()
        {
            InitializeComponent();
        }
    }
}
