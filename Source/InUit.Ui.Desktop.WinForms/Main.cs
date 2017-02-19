using InUit.Model;
using InUit.Model.Bookkeeping;
using InUit.Model.Periods;
using InUit.Ui.Desktop.WinForms.Common;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InUit.Ui.Desktop.WinForms
{
    public partial class Main : Form
    {
        private AppContext _appCtx = null;
        private bool _quit = false;

        public Main(AppContext appContext) {
            InitializeComponent();

            KeyPreview = true;

            if (appContext == null) {
                throw new ArgumentNullException(nameof(appContext));
            }
            _appCtx = appContext;
            _appCtx.Settings.Save();

            UpdateOrInitiateWorkingDirectory();
            UpdateIcon();
            UpdateTitle();
            UpdateBook();
        }

        #region Ui Updates
        private void UpdateOrInitiateWorkingDirectory() {
            if (!_appCtx.Settings.HasWorkingDirectory) {
                var result = MessageBox.Show(this, "De applicatie heeft geen werkmap. Druk op OK om een werkmap te selecteren.", "Selecteer een werkmap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var folderBrowser = new FolderBrowserDialog() {
                    Description = "De applicatie heeft een werkmap nodig om gegevens op te slaan. Kies een reeds bestaande werkmap, of maak een nieuwe aan.",
                };
                do {
                    var folderResult = folderBrowser.ShowDialog(this);
                    if (folderResult == DialogResult.Cancel) {
                        _quit = true;
                        break;
                    }
                } while (!Directory.Exists(folderBrowser.SelectedPath));

                if (_quit) {
                    this.Close();
                }
                else {
                    _appCtx.Settings.WorkingDirectory = new DirectoryInfo(folderBrowser.SelectedPath);
                    _appCtx.Settings.Save();
                }
            }
        }

        private void UpdateIcon() {
            Icon = ResourceExtractor.GetIcon("InUit_MultiSize.ico");
        }

        private void UpdateTitle() {
            Text = $"In/Uit [v.{Application.ProductVersion} | {_appCtx.Period.Current.Name} | {_appCtx.UserProvider.GetLoggedInUser().ShortLogonName.ToUpper()}]";
        }

        private void UpdateBook() {
            uxIn.Items.Clear();
            uxOut.Items.Clear();

            var book = _appCtx.Books.GetOrCreate(_appCtx.Period.Current);
            foreach (var line in book.Lines.OrderBy(l => l.ToString())) {
                switch (line.Category) {
                    case LineCategory.In:
                        uxIn.Items.Add(line, line.IsOk);
                        break;
                    case LineCategory.Out:
                        uxOut.Items.Add(line, line.IsOk);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(line.Category), "Unknown category.");
                }
            }
        }
        #endregion

        #region Events
        private void uxIn_Click(object sender, EventArgs e) {
            if (CheckInput(uxInOutName.Text)) {
                var book = _appCtx.Books.GetOrCreate(new Period(uxInOutDateTime.Value));
                book.AddLine(new Line {
                    Category = LineCategory.In,
                    IsOk = false,
                    Name = uxInOutName.Text.Trim().Replace("+", "").Replace("-", ""),
                    When = uxInOutDateTime.Value
                });
                book = _appCtx.Books.Save(book);
            }

            uxInOutName.Text = "";
            UpdateBook();
        }

        private void uxOut_Click(object sender, EventArgs e) {
            if (CheckInput(uxInOutName.Text)) {
                var book = _appCtx.Books.GetOrCreate(new Period(uxInOutDateTime.Value));
                book.AddLine(new Line {
                    Category = LineCategory.Out,
                    IsOk = false,
                    Name = uxInOutName.Text.Trim().Replace("+", "").Replace("-", ""),
                    When = uxInOutDateTime.Value
                });
                _appCtx.Books.Save(book);
            }

            uxInOutName.Text = "";
            UpdateBook();
        }

        private void uxPeriod_ValueChanged(object sender, EventArgs e) {
            _appCtx.Period.Reset(uxPeriod.Value);
            PeriodChanged();
        }
        private void PeriodChanged() {
            UpdateTitle();
            UpdateBook();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Up) {
                ChangePeriod(_appCtx.Period.Next());
                e.Handled = true;
            }
            if (e.KeyData == Keys.Down) {
                ChangePeriod(_appCtx.Period.Previous());
                e.Handled = true;
            }            
        }
        private void ChangePeriod(Period period) {
            uxPeriod.Value = new DateTime(period.Year, period.Month, 1);
        }

        private bool CheckInput(string name) {
            try {
                if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentNullException(nameof(name), "Please enter a valid name.");
                }
                if (name.Replace("+", "").Replace("-", "").Trim().Equals(String.Empty)) {
                    throw new ArgumentNullException(nameof(name), "Please enter a valid name.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.ToString(), "Error while adding new line...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void uxInOutName_TextChanged(object sender, EventArgs e) {
            if (uxInOutName.Text.EndsWith("+")) {
                uxIn_Click(null, null);
            }
            if (uxInOutName.Text.EndsWith("-")) {
                uxOut_Click(null, null);
            }
        }

        private void uxIn_ItemCheck(object sender, ItemCheckEventArgs e) {
            Update(uxIn, e.Index, e.NewValue);
        }
        private void uxOut_ItemCheck(object sender, ItemCheckEventArgs e) {
            Update(uxOut, e.Index, e.NewValue);
        }

        private void Update(CheckedListBox listBox, int index, CheckState checkState) {
            var line = listBox.Items[index] as Line;
            var book = _appCtx.Books.GetOrCreate(_appCtx.Period.Current);
            book.UpdateLine(line, checkState == CheckState.Checked);
            _appCtx.Books.Save(book);
        }
        #endregion        
    }
}
