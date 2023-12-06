using StudentLib;

namespace Student_Management_Windows_Forms
{
    public partial class frmStudentManagement : Form
    {
        private BindingSource bs = new();
        public frmStudentManagement()
        {
            InitializeComponent();
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            cboCreateMajor.DataSource = Enum.GetValues<Major>();
            cboUpdateMajor.DataSource = Enum.GetValues<Major>();
            bs.DataSource = new List<StudentResponse>();
            dgvStudents.DataSource = bs;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            btnRefresh.Click += DoClickRefresh;

            btnCreateSubmit.Click += DoClickCreateSubmit;

            bs.PositionChanged += DoProductPositionChanged;

            btnUpdateSubmit.Click += DoClickUpdateSubmit;

            btnDelete.Click += DoClickDelete;

            btnClear.Click += DoClickCreateClear;
        }

        private void DoClickCreateClear(object? sender, EventArgs e)
        {
            txtCreateCode.Clear();
            txtCreateName.Clear();
            cboCreateMajor.SelectedItem = Major.None;
        }

        private async void DoClickDelete(object? sender, EventArgs e)
        {
            if (bs.Current == null) return;
            if (bs.Current is not StudentResponse prd) return;
            string endpoint = $"api/students/{prd.Id}";
            var result = await Program.RestClient.DeleteAsync<Result<string?>>(endpoint);
            if (result!.Succeded && prd.Id == result!.Data)
            {
                bs.RemoveCurrent();
                bs.ResetBindings(false);
            }
            MessageBox.Show(result!.Message);
        }

        private async void DoClickUpdateSubmit(object? sender, EventArgs e)
        {
            string endpoint = "api/students";
            Major cat = ((Major)cboUpdateMajor.SelectedItem);
            var req = new StudentUpdateReq()
            {
                Key = txtUpdateCode.Text,
                Name = txtUpdateName.Text,
                Major = cat == Major.None ? null : cat.ToString()
            };
            var result = await Program.RestClient.PutAsync<StudentUpdateReq, Result<string?>>(endpoint, req);
            Task task = Task.Run(async () =>
            {
                if (result!.Succeded)
                {
                    endpoint = $"api/students/{result!.Data!}";
                    var foundResult = await Program.RestClient.GetAsync<Result<StudentResponse?>>(endpoint);
                    if (foundResult!.Succeded && foundResult.Data != null)
                    {
                        var found = (bs.DataSource as List<StudentResponse>)?.FirstOrDefault(b => b.Id == foundResult.Data.Id);
                        if (found != null)
                        {
                            found.Name = foundResult.Data.Name;
                            found.Major = foundResult.Data.Major;
                            bs.ResetBindings(false);
                        }
                    }
                }
            });
            MessageBox.Show(result!.Message);
            task.Wait();
        }

        private void DoProductPositionChanged(object? sender, EventArgs e)
        {
            if (bs.Current == null)
            {
                txtUpdateCode.Clear();
                txtUpdateName.Clear();
                cboUpdateMajor.SelectedItem = Major.None;
            }
            else
            {
                if (bs.Current is StudentResponse prd)
                {
                    txtUpdateCode.Text = prd.Code.ToString();
                    txtUpdateName.Text = prd.Name;
                    Major cat = Major.None;
                    Enum.TryParse<Major>(prd.Major ?? "", out cat);
                    cboUpdateMajor.SelectedItem = cat;
                }
            }
        }

        private async void DoClickCreateSubmit(object? sender, EventArgs e)
        {
            string endpoint = "api/students";
            Major cat = ((Major)cboCreateMajor.SelectedItem);
            var req = new StudentCreateReq()
            {
                Code = txtCreateCode.Text,
                Name = txtCreateName.Text,
                Major = cat == Major.None ? null : cat.ToString()
            };
            var result = await Program.RestClient.PostAsync<StudentCreateReq, Result<string?>>(endpoint, req);
            Task task = Task.Run(async () =>
            {
                if (result!.Succeded)
                {
                    endpoint = $"api/students/{result!.Data}";
                    var foundResult = await Program.RestClient.GetAsync<Result<StudentResponse?>>(endpoint);
                    if (foundResult!.Succeded && foundResult.Data != null)
                    {
                        (bs.DataSource as List<StudentResponse>)?.Add(foundResult.Data);
                        bs.ResetBindings(false);
                    }
                }
            });
            MessageBox.Show(result!.Message);
        }

        private async void DoClickRefresh(object? sender, EventArgs e)
        {
            string endpoint = "api/students";
            var result = await Program.RestClient.GetAsync<Result<List<StudentResponse>>>(endpoint);
            if (result!.Succeded == true)
            {
                bs.DataSource = result.Data;
                bs.ResetBindings(false);
            }
        }

        private async void frmStudentManagement_Load(object sender, EventArgs e)
        {
            string endpoint = "api/students";
            var result = await Program.RestClient.GetAsync<Result<List<StudentResponse>>>(endpoint);
            if (result!.Succeded == true)
            {
                bs.DataSource = result.Data;
                bs.ResetBindings(false);

            }
        }
    }
}