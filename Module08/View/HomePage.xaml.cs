namespace Module08.View
{
    public partial class HomePage : ContentPage
    {
        int count = 0;

        public HomePage()
        {
            InitializeComponent();
        }


        private async void ClickedViewUser(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//UserPage");
        }

        private async void ClickedViewStudent(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//StudentListPage");
        }

        private async void OnTestDbConnection(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("http://localhost/pdc50/test_connection.php");
                    var result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ConnectionStatus.Text = "Student Record Connection Successful";
                        ConnectionStatus.TextColor = Colors.Green;
                    }
                    else
                    {
                        ConnectionStatus.Text = "Student Record Connection Failed";
                        ConnectionStatus.TextColor = Colors.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionStatus.Text = $"Error: {ex.Message}";
                ConnectionStatus.TextColor = Colors.Red;
            }
        }

    }

}
