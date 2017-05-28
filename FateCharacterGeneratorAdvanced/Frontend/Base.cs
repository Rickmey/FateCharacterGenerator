using FateCharacterGeneratorAdvanced.Backend;
using FateCharacterGeneratorAdvanced.Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FateCharacterGeneratorAdvanced
{
    public partial class Base : Form
    {
        private static readonly string nameTextBox = "nameTextBox";
        private static readonly string genderPictureBox = "genderPictureBox";
        private static readonly string skillListView = "skillListView";
        private static readonly string descriptionTextBox = "descriptionTextBox";
        private Font defaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular);
        private Font nameTextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25f, FontStyle.Regular);
        private Bitmap maleIcon = new Bitmap(Resources.GfxPath + "male.png");
        private Bitmap femaleIcon = new Bitmap(Resources.GfxPath + "female.png");
        private Bitmap questionmarkIcon = new Bitmap(Resources.GfxPath + "questionmark.png");

        public Base()
        {
            InitializeComponent();
            this.tabControl.Font = defaultFont;
            this.chooseGenderIcon.Image = this.questionmarkIcon;
        }


        #region Events

        private void generateButton_Click(object sender, EventArgs e)
        {
            FateCharacter fateCharacter = FateCharacter.GetRandomChar(BaseState.Instance.isMale, BaseState.Instance.isFemale);
            this.showCharacter(fateCharacter);
        }


        private void Base_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.closeTab();
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.closeTab();
        }

        private void Base_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.addTab();
        }

        private void tabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.addTab();
        }

        private void Base_Load(object sender, EventArgs e)
        {
            if (this.loadDefaultCharacterOnStartup() <= 0)
                this.addTab();
            this.MinValueTextBox.Text = "0";
            this.MaxValueTextBox.Text = "1";
        }

        private void ValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsControl(c) || char.IsLetter(c))
            {
                e.Handled = true;
            }
        }

        private void chooseGenderIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (BaseState.Instance.isFemale && BaseState.Instance.isMale)
            {
                BaseState.Instance.isFemale = false;
                this.chooseGenderIcon.Image = this.maleIcon;
                return;
            }

            if (BaseState.Instance.isMale)
            {
                BaseState.Instance.isFemale = true;
                BaseState.Instance.isMale = false;
                this.chooseGenderIcon.Image = this.femaleIcon;
                return;
            }

            if (BaseState.Instance.isFemale)
            {
                BaseState.Instance.isMale = true;
                this.chooseGenderIcon.Image = this.questionmarkIcon;
                return;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            FateCharacter fc = BaseState.Instance.CharacterMap[this.getCurrentTab()];
            if (fc == null)
                return;
            if (this.loadOnStartCheckbox.Checked) { fc.LoadOnStart = true; }
            fc.Description = this.trimText(this.getCurrentDescriptionTextBox().Text);
            string saveAs = string.Format("{0}{1}.fcga", Resources.SavePath, fc.Name.Replace(" ", "_"));
            fc.IsSaved = Serializer.WriteJson<FateCharacter>(saveAs, fc, false);
        }

        private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Resources.SavePath;
            openFileDialog.ShowDialog();
            string filepath = openFileDialog.FileName;
            FateCharacter fc = Serializer.ReadJson<FateCharacter>(filepath);
            this.showCharacter(fc);
        }


        private void HideSkillsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Dictionary<string, ushort> dic = this.HideSkillsCheckbox.Checked ? null : this.getCurrentFateCharacter().Skills;
            this.addListViewItems(dic);
        }

        private void RandomThrowButton_MouseClick(object sender, MouseEventArgs e)
        {
            int min;
            Int32.TryParse(this.MinValueTextBox.Text, out min);
            int max;
            Int32.TryParse(this.MaxValueTextBox.Text, out max);
            if (min > max)
            {
                max = min;
                this.MaxValueTextBox.Text = max.ToString();
            }

            this.RandomResultTextBox.Text = Resources.Rdm.Next(min, max + 1).ToString();
        }

        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                TextBox tb = (TextBox)sender;
                tb.SelectAll();
            }
            else if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
        }

        #endregion Events


        #region Methods

        private string trimText(string text)
        {
            return text;
            //return text.Replace("\r", " ").Replace("\n", "").Replace("\t", " ");
        }

        private int loadDefaultCharacterOnStartup()
        {
            string[] fileNames = Serializer.ReadFileNamesFromDirectory(Resources.SavePath, "*.fcga");
            int count = 0;
            foreach (string filepath in fileNames)
            {
                FateCharacter fc = Serializer.ReadJson<FateCharacter>(filepath);
                if (fc == null) continue;
                if (!fc.LoadOnStart) continue;
                this.addTab();
                this.showCharacter(fc);
                count++;
            }
            return count;
        }

        private void showCharacter(FateCharacter fateCharacter)
        {
            TabPage tabPage = this.getCurrentTab();
            BaseState.Instance.CharacterMap[tabPage] = fateCharacter;
            tabPage.Controls[Base.nameTextBox + tabPage.TabIndex].Text = fateCharacter.Name;
            tabPage.Text = fateCharacter.Name;
            this.addListViewItems(fateCharacter.Skills);
            this.setGenderIcon((PictureBox)tabPage.Controls[Base.genderPictureBox], fateCharacter.IsMale);
            this.getCurrentDescriptionTextBox().Text = fateCharacter.Description;
        }

        private TextBox createNameTextBox(int tabindex)
        {
            TextBox tb = new TextBox();
            tb.Location = new System.Drawing.Point(21, 20);
            tb.Font = this.nameTextBoxFont;
            tb.Name = Base.nameTextBox + tabindex;
            tb.Size = new System.Drawing.Size(200, 20);
            return tb;
        }

        private void closeTab()
        {
            if (tabControl.Controls.Count <= 1)
                return;
            TabPage tp = this.getCurrentTab();
            BaseState.Instance.CharacterMap.Remove(tp);
            this.tabControl.TabPages.Remove(tp);
        }

        private void addTab()
        {
            TabPage tabPage = new TabPage();
            tabPage.Font = this.defaultFont;
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(516, 460);
            tabPage.UseVisualStyleBackColor = true;
            tabPage.TabIndex = ++this.tabControl.TabIndex;

            tabPage.Controls.Add(this.getListView());
            tabPage.Controls.Add(this.createNameTextBox(tabPage.TabIndex));
            tabPage.Controls.Add(this.getGenderIcon());
            tabPage.Controls.Add(this.getDescriptionTextBox());
            tabControl.TabPages.Add(tabPage);

            BaseState.Instance.CharacterMap.Add(tabPage, null);

            // setzt fokus
            this.tabControl.SelectTab(tabPage);
        }

        private TextBox getDescriptionTextBox()
        {
            TextBox tb = new TextBox();
            tb.ShortcutsEnabled = true;
            tb.Multiline = true;
            tb.Location = new System.Drawing.Point(280, 20);
            tb.Font = this.defaultFont;
            tb.Name = Base.descriptionTextBox;
            tb.Size = new System.Drawing.Size(200, 414);
            tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
            return tb;
        }

        private ListView getListView()
        {
            ListView lv = new ListView();
            lv.Location = new System.Drawing.Point(22, 75);
            lv.Size = new System.Drawing.Size(220, 360);
            lv.Name = Base.skillListView;
            lv.Font = this.defaultFont;
            lv.View = View.Details;
            ColumnHeader columnHeaderSkill = new ColumnHeader();
            columnHeaderSkill.Text = "Skill";
            columnHeaderSkill.Width = 150;
            lv.Columns.Add(columnHeaderSkill);

            ColumnHeader columnHeaderScore = new ColumnHeader();
            columnHeaderScore.Text = "Score";
            columnHeaderScore.Width = 50;
            columnHeaderScore.TextAlign = HorizontalAlignment.Center;
            lv.Columns.Add(columnHeaderScore);
            return lv;
        }

        private void addListViewItems(Dictionary<string, ushort> dic)
        {
            ListView lv = this.getCurrentSkillListView();
            lv.Items.Clear();
            if (this.HideSkillsCheckbox.Checked) { return; }
            if (dic == null) { return; }

            foreach (KeyValuePair<string, ushort> kvp in dic)
            {
                lv.Items.Add(new ListViewItem(new string[] { kvp.Key, kvp.Value.ToString() }));
            }
        }

        private PictureBox getGenderIcon()
        {
            PictureBox pb = new PictureBox();
            pb.Name = Base.genderPictureBox;
            return pb;
        }

        private void setGenderIcon(PictureBox pb, bool isMale)
        {
            pb.Image = isMale ? this.maleIcon : this.femaleIcon;
        }

        #endregion Methods

        #region Utility

        private TabPage getCurrentTab()
        {
            return this.tabControl.SelectedTab;
        }

        private ListView getCurrentSkillListView()
        {
            return (ListView)this.getCurrentTab().Controls[Base.skillListView];
        }

        private FateCharacter getCurrentFateCharacter()
        {
            return BaseState.Instance.CharacterMap[this.getCurrentTab()];
        }

        private TextBox getCurrentDescriptionTextBox()
        {
            return (TextBox)this.getCurrentTab().Controls[Base.descriptionTextBox];
        }

        #endregion Utility

    }
}
