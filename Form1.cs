using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;


namespace My_Rakhivnytsia
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Vlad Vlad/source/repos/My_Rakhivnytsia/Users1.accdb;";
        public OleDbConnection myConnection1;

        public bool flag = false;

        DataGridView data; // Компонент для відображення та редагування таблиць

        Label labelBalance;
        Label labelBalanceSum;

        TextBox LoginBox; // Поле введення логіну 
        TextBox PassBox; // Поле введення паролю
        TextBox PassConfBox; // Поле підтвердження паролю
        TextBox SumBox; // Поле введення суми платежу
        TextBox DescriptionBox; // Поле введення опису
        TextBox textBoxIndex;
        TextBox SearchByLogin; // Пошук по логіну
        TextBox SearchByName; // Пошук по імені
        TextBox SearchByLastName; // Пошук по прізвищу
        TextBox SearchByAge; // Пошук по віку
        TextBox textBox1;
        ComboBox TypeOfTransaction;

        Font LabelFont = new Font("Segoe UI", 12);
        Font DataFont = new Font("Segoe UI", 10);
        Font LoginFont = new Font("Segoe UI", 18);
        Label label; // Надпис

        CheckBox IncomeCheck; // Прапорець "Дохід"
        CheckBox ExpenceCheck; // Прапорець "Витрати"

        Button AddTransaction; // Кнопка додання прибутку
        Button RegButton; // Кнопка реєстрації
        Button LoginButton; // Кнопка входу 
        Button AddTransactionButton;
        Button DeleteRecord; // Кнопка видадення запису з таблиці
        Button UpdateBalance;
        Button SumButton; // Оновлення балансу
        Button TypeButton; // Тип транзакції

        RadioButton IncomeRadioButton; // Вибір типу транзакції "Дохід"
        RadioButton ExpencesRadioButton; // Вибір типу транзакції "Витрати"

        DateTimePicker DateTimePicker1; // Елемент вибору дати 

        public Form1()
        {
            InitializeComponent();
            myConnection1 = new OleDbConnection(connectionString);
            myConnection1.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection1.Close();
        }

        private void IncomeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IncomeCheck.Checked)
            {
                (data.DataSource as DataTable).DefaultView.RowFilter = $"[Тип транзакції] LIKE 'Дохід'";
            }
            else
            {
                MessageBox.Show("Відобразити повну таблицю");
                балансToolStripMenuItem_Click(null,null);
            }
           
        }

        private void ExpenceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ExpenceCheck.Checked)
            {
                (data.DataSource as DataTable).DefaultView.RowFilter = $"[Тип транзакції] LIKE 'Витрати'";
            }
            else
            {
                MessageBox.Show("Відобразити повну таблицю");
                балансToolStripMenuItem_Click(null, null);
            }
        }

        private void вхідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            label = new Label();
            label.Text = "Логін:";
            label.Visible = true;
            label.Location = new Point(552, 100);
            label.ForeColor = Color.DarkCyan;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = LoginFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);
            //
            LoginBox = new TextBox();
            LoginBox.Visible = true;
            LoginBox.Width = 400;
            LoginBox.Font = LabelFont;
            LoginBox.Location = new Point(400, 200);
            panel1.Controls.Add(LoginBox);
            //
            label = new Label();
            label.Text = "Пароль:";
            label.Visible = true;
            label.Location = new Point(536, 300);
            label.ForeColor = Color.DarkCyan;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = LoginFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);
            //
            PassBox = new TextBox();
            PassBox.Visible = true;
            PassBox.PasswordChar = '●';
            PassBox.Location = new Point(400, 400);
            PassBox.Width = 400;
            PassBox.Font = LabelFont;
            panel1.Controls.Add(PassBox);
            //
            LoginButton = new Button();
            LoginButton.Text = "Увійти";
            LoginButton.Visible = true;
            LoginButton.Location = new Point(533, 500);
            LoginButton.Font = LabelFont;
            LoginButton.ForeColor = Color.DarkCyan;
            LoginButton.AutoSize = true;
            panel1.Controls.Add(LoginButton);
            LoginButton.Click += new EventHandler(LoginButton_Click);


        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Перевірка введених користувачем даних - перевірка на заповнені поля


string query = "SELECT [Логін], [Password] FROM Users_Table";
            OleDbCommand command = new OleDbCommand(query, myConnection1);
            OleDbDataReader dbReader = command.ExecuteReader();
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Помилка, спробуйте пізніше!");
            }
            else
            {
                while (dbReader.Read())
                {
                    // Перевірка введених користувачем даних - перевірка на правильність заповнення полів

                    if (LoginBox.Text == dbReader["Логін"].ToString() && PassBox.Text == dbReader["Password"].ToString())
                    {
                        flag = true;
                        балансToolStripMenuItem_Click(null, null);
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("Ви ввели неправильний логін або пароль!");
                }
            }

        }



        // пункт меню "Реєстрація"
        private void реєстраціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створення нового логіну - створення підпису "Логін" 
            panel1.Controls.Clear();
            label = new Label();
            label.Text = "Логін:";
            label.Visible = true;
            label.Location = new Point(100, 100);
            label.ForeColor = Color.DarkCyan;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = LoginFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);

            // Створення нового логіну - створення поля введення логіну
            LoginBox = new TextBox();
            LoginBox.Visible = true;
            LoginBox.Location = new Point(250, 100);
            LoginBox.Width = 250;
            LoginBox.Font = LoginFont;
            panel1.Controls.Add(LoginBox);



            // Створення нового паролю - створення підпису "Пароль"
            label = new Label();
            label.Text = "Пароль:";
            label.Visible = true;
            label.Font = LabelFont;
            label.Location = new Point(100, 200);
            label.ForeColor = Color.DarkCyan;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = LoginFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);

            // Створення нового паролю - створення поля введення паролю
            PassBox = new TextBox();
            PassBox.Visible = true;
            PassBox.PasswordChar = '●'; // відображення введених символів паролю одним символом '●'
            PassBox.Location = new Point(250, 200);
            PassBox.Width = 250;
            PassBox.Font = LoginFont;
            panel1.Controls.Add(PassBox);

            // Підтвердження введеного паролю - створення підпису "Підтвердіть пароль:"
            label = new Label();
            label.Text = "Підтвердіть пароль:";
            label.Visible = true;
            label.Location = new Point(100, 300);
            label.ForeColor = Color.DarkCyan;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = LoginFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);

            // Підтвердження введеного паролю - створення поля введення підтвердженого паролю
            PassConfBox = new TextBox();
            PassConfBox.Visible = true;
            PassConfBox.PasswordChar = '●'; // відображення введених символів паролю одним символом '●'
            PassConfBox.Location = new Point(350, 300);
            PassConfBox.Width = 250;
            PassConfBox.Font = LoginFont;
            panel1.Controls.Add(PassConfBox);

            // Кнопка "Зареєструватися"
            RegButton = new Button();
            RegButton.Text = "Зареєструватися";
            RegButton.Visible = true;
            RegButton.Location = new Point(400, 500);
            RegButton.Font = LoginFont;
            RegButton.ForeColor = Color.DarkCyan;
            RegButton.AutoSize = true;
            panel1.Controls.Add(RegButton);
            RegButton.Click += new EventHandler(RegButton_Click);


        }

// Процес реєстрації користувача
        private void RegButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginBox.Text) && !string.IsNullOrWhiteSpace(PassBox.Text) && PassBox.Text == PassConfBox.Text)
            {
                string query = "SELECT [Логін] FROM Users_Table";
                OleDbCommand command = new OleDbCommand(query, myConnection1);
                OleDbDataReader dbReader = command.ExecuteReader();
                bool login_isset = false;
                while (dbReader.Read())
                {
                    if (LoginBox.Text == dbReader["Логін"].ToString())
                    {
                        login_isset = true;
                    }
                }

                if (login_isset)
                {
                    MessageBox.Show("Користувач із таким логіном вже існує!");
                    реєстраціяToolStripMenuItem_Click(null, null);
                }
                else
                {
                    // Внесення введених даних в базу даних 

                    string query_ins = $"INSERT INTO Users_Table ([Логін], [Password]) VALUES ('{LoginBox.Text}', '{PassBox.Text}')";
                    OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                    int result = command_ins.ExecuteNonQuery();
                    if (result != 0)
                    {
                        MessageBox.Show("Ви успішно зареєструвалися!");
                        вхідToolStripMenuItem_Click(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Виникла помилка під час реєстрації, повторіть спробу!");
                    }
                }


            }
            else
            {
                // У випадку, коли не всі поля введені

                MessageBox.Show("Заповніть усі поля у формі!");
            }

        }


        // ////////ДОДАНННЯ ПРИБУТКУ /////////////////////////////////////////////////////////////////
        private void AddTransaction_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(LoginBox.Text) && !string.IsNullOrWhiteSpace(PassConfBox.Text) && PassConfBox.Text == PassBox.Text && !string.IsNullOrWhiteSpace(SumBox.Text) && !string.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                string query = "SELECT [Сума],[Опис] FROM Users_Table";
                OleDbCommand command = new OleDbCommand(query, myConnection1);
                OleDbDataReader dbReader = command.ExecuteReader();
                bool login_isset = false;
                while (dbReader.Read())
                {
                    // Внесення введених даних в базу даних 

                    string query_ins = $"INSERT INTO Users_Table ([Логін], [Password],[Сума],[Тип транзакції],[Опис],[Дата]) VALUES ('{LoginBox.Text}', '{PassBox.Text}','{SumBox.Text}', '{textBox1.Text}','{DescriptionBox.Text}', '{DateTimePicker1.Value}')";
                    OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                    int result = command_ins.ExecuteNonQuery();
                    if (result != 0)
                    {
                        MessageBox.Show("Транзакцію внесено");
                        балансToolStripMenuItem_Click(null, null);
                    }

                    break;
                }


            }
            else
            {
                MessageBox.Show("Заповніть всі поля форми або введіть правильний пароль!");
            }


        }

        private void DeleteRecord_Click(object sender, EventArgs e)
        {
            int indexRow = data.CurrentCell.RowIndex;
            int indexColumn = data.CurrentCell.ColumnIndex;

            

            string id_value = data.Rows[indexRow].Cells[indexColumn].Value.ToString();



            string query = "SELECT [ID]  FROM Users_Table";
            OleDbCommand command = new OleDbCommand(query, myConnection1);
            OleDbDataReader dbReader = command.ExecuteReader();
            while (dbReader.Read())
            {
                string query_ins = $"DELETE FROM Users_Table WHERE ID={id_value}"; // ID номер
                OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                command_ins.ExecuteNonQuery();
            }
            MessageBox.Show("Транзакцію видалено");
            балансToolStripMenuItem_Click(null, null);
        }

        void generate_Filter_Balance()
        {
            // Фільтрування за типом транзакції

            label = new Label();
            label.Text = "Фільтрувати за:";
            label.Visible = true;
            label.AutoSize = true;
            label.Location = new Point(134, 300);
            label.ForeColor = Color.DarkCyan;
            label.Font = LabelFont;
            label.AutoSize = true;
            panel1.Controls.Add(label);

            IncomeCheck = new CheckBox();
            IncomeCheck.Text = "Дохід";
            IncomeCheck.Visible = true;
            IncomeCheck.AutoSize = true;
            IncomeCheck.Location = new Point(434, 300);
            IncomeCheck.Font = LabelFont;
            panel1.Controls.Add(IncomeCheck);
            IncomeCheck.CheckedChanged += new EventHandler(IncomeCheck_CheckedChanged);

            ExpenceCheck = new CheckBox();
            ExpenceCheck.Text = "Витрати";
            ExpenceCheck.Visible = true;
            ExpenceCheck.AutoSize = true;
            ExpenceCheck.Location = new Point(634, 300);
            ExpenceCheck.Font = LabelFont;
            panel1.Controls.Add(ExpenceCheck);
            ExpenceCheck.CheckedChanged += new EventHandler(ExpenceCheck_CheckedChanged);


            labelBalance = new Label();
            labelBalance.Text = "Ваш поточний баланс складає:";
            labelBalance.Visible = true;
            labelBalance.AutoSize = true;
            labelBalance.ForeColor = Color.Black;
            labelBalance.Font = LabelFont;
            labelBalance.AutoSize = true;
            labelBalance.Location = new Point(134, 400);
            panel1.Controls.Add(labelBalance);
            //


            labelBalanceSum = new Label();


            labelBalanceSum.Visible = true;
            labelBalanceSum.AutoSize = true;
            labelBalanceSum.ForeColor = Color.DarkCyan;
            labelBalanceSum.Location = new Point(484, 400);
            labelBalanceSum.AutoSize = true;
            labelBalanceSum.ForeColor = Color.DarkCyan;
            labelBalanceSum.Font = LabelFont;
            labelBalanceSum.AutoSize = true;
            panel1.Controls.Add(labelBalanceSum);
            
            label = new Label();
            label.Text = "грн";
            label.Visible = true;
            label.AutoSize = true;
            label.Font = LabelFont;
            label.Location = new Point(564, 400);
            panel1.Controls.Add(label);

            DeleteRecord = new Button();
            DeleteRecord.Text = "Видалити запис";
            DeleteRecord.Visible = true;
            DeleteRecord.AutoSize = true;
            DeleteRecord.Font = LabelFont;
            DeleteRecord.ForeColor = Color.DarkCyan;
            DeleteRecord.Location = new Point(134, 450);
            panel1.Controls.Add(DeleteRecord);
            DeleteRecord.Click += new EventHandler(DeleteRecord_Click);


            textBoxIndex = new TextBox();
            textBoxIndex.Visible = false;
            textBoxIndex.Location = new Point(950, 950);
            textBoxIndex.Width = 250;
            panel1.Controls.Add(textBoxIndex);


            //
            string query = "SELECT SUM (Сума) FROM Users_Table";
            using (System.Data.IDbCommand command = new System.Data.OleDb.OleDbCommand(query, myConnection1))
            {
                object result = command.ExecuteScalar();
                labelBalanceSum.Text = Convert.ToString(result);
            }
        }




        private void балансToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Ви не авторизувалися! Авторизуйтесь!");
            }
            else
            {
                panel1.Controls.Clear();
                data = new DataGridView();
                data.Visible = true;
                data.EnableHeadersVisualStyles = false;
                data.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
                data.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                data.ColumnHeadersDefaultCellStyle.Font = DataFont;
                data.Location = new Point(10, 10);
                data.AllowUserToDeleteRows = true;
                data.Location = new Point(134,10) ; 
                data.Width = 963;
                data.Height = 260;
                panel1.Controls.Add(data);

                generate_Filter_Balance();


                data.Rows.Clear();
                string query = "SELECT [ID], [Логін], [Сума], [Тип транзакції], [Опис], [Дата] FROM [Users_Table]";


DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConnection1);
                adapter.Fill(ds);
                data.DataSource = ds.Tables[0];
            }
        }



        private void додаванняТранзакціїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Ви не авторизувалися! Авторизуйтесь!");
            }
            else
            {
                panel1.Controls.Clear();



                // Введення суми платежу - створення підпису "Сума:"
                label = new Label();
                label.Text = "Пароль:";
                label.Visible = true;
                label.Location = new Point(100, 100);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                // Введення суми платежу - створення поля введення імені користувача
                PassConfBox = new TextBox();
                PassConfBox.Visible = true;
                PassConfBox.PasswordChar = '●';
                PassConfBox.Location = new Point(250, 100);
                PassConfBox.Font = LabelFont;
                PassConfBox.Width = 250;
                panel1.Controls.Add(PassConfBox);

                // Введення суми платежу - створення підпису "Сума:"
                label = new Label();
                label.Text = "Сума:";
                label.Visible = true;
                label.Location = new Point(100, 150);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                SumBox = new TextBox();
                SumBox.Visible = true;
                SumBox.Location = new Point(250, 150);
                SumBox.Width = 250;
                SumBox.Font = LabelFont;
                panel1.Controls.Add(SumBox);

                label = new Label();
                label.Text = "Опис:";
                label.Visible = true;
                label.Location = new Point(100, 200);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                // 
                DescriptionBox = new TextBox();
                DescriptionBox.Visible = true;
                DescriptionBox.Location = new Point(250, 200);
                DescriptionBox.Width = 250;
                DescriptionBox.Font = LabelFont;
                panel1.Controls.Add(DescriptionBox);

                // Введення суми платежу - створення підпису "Вид транзакції:"
                label = new Label();
                label.Text = "Вид транзакції:";
                label.AutoSize = true;
                label.Visible = true;
                label.Location = new Point(100, 250);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);


                IncomeRadioButton = new RadioButton();
                IncomeRadioButton.Visible = true;
                IncomeRadioButton.Location = new Point(100, 400);
                IncomeRadioButton.AutoSize = true;
                IncomeRadioButton.Text = "Дохід";
                IncomeRadioButton.Font = LabelFont;
                panel1.Controls.Add(IncomeRadioButton);
                IncomeRadioButton.CheckedChanged += new EventHandler(IncomeRadioButton_CheckedChanged);
                //
                ExpencesRadioButton = new RadioButton();
                ExpencesRadioButton.Visible = true;
                ExpencesRadioButton.Location = new Point(100, 400);
                ExpencesRadioButton.AutoSize = true;
                ExpencesRadioButton.Text = "Витрати";
                ExpencesRadioButton.Font = LabelFont;
                ExpencesRadioButton.CheckedChanged += new EventHandler(ExpencesRadioButton_CheckedChanged);

                panel1.Controls.Add(ExpencesRadioButton);
                //

                textBox1 = new TextBox();
                textBox1.Visible = false;
                textBox1.Location = new Point(250, 600);
                textBox1.Width = 250;
                panel1.Controls.Add(textBox1);

                
                // Кнопка "Додати транзакцію"
                AddTransaction = new Button();
                AddTransaction.Text = "Додати транзакцію";
                AddTransaction.Visible = true;
                AddTransaction.Location = new Point(100, 550);
                AddTransaction.AutoSize = true;
                panel1.Controls.Add(AddTransaction);
                AddTransaction.Click += new EventHandler(AddTransaction_Click);







                if (!string.IsNullOrWhiteSpace(LoginBox.Text) && !string.IsNullOrWhiteSpace(PassBox.Text) && !string.IsNullOrWhiteSpace(SumBox.Text))
                {
                    string query = "SELECT Логін FROM Users_Table";
                    OleDbCommand command = new OleDbCommand(query, myConnection1);
                    OleDbDataReader dbReader = command.ExecuteReader();
                    bool login_isset = false;
                    while (dbReader.Read())
                    {
                        if (LoginBox.Text == dbReader["Логін"].ToString())
                        {
                            login_isset = true;
                        }
                    }

                    if (login_isset)
                    {
                        MessageBox.Show("Користувач із таким логіном вже існує!");
                        реєстраціяToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        // Внесення введених даних в базу даних 

                        string query_ins = $"INSERT INTO Users_Table ([Логін], [Password], [Сума],[Тип транзакції],[Опис],[Дата]) VALUES ('{LoginBox.Text}', '{PassBox.Text}', '{SumBox.Text}', '{DescriptionBox.Text}','{DateTimePicker1.Value}')";
                        OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                        int result = command_ins.ExecuteNonQuery();
                        if (result != 0)
                        {
                            MessageBox.Show("Ви успішно зареєструвалися!");
                            вхідToolStripMenuItem_Click(null, null);

                        }
                        else
                        {
                            MessageBox.Show("Виникла помилка під час реєстрації, повторіть спробу!");
                        }
                    }
                }
            }
        }

        void IncomeRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (IncomeRadioButton.Checked)
            {
                textBox1.Text = "Дохід";
            }
            else
            {
                textBox1.Text = "Витрати";
                SumBox.Text = "-" + SumBox.Text;
            }
        }

        void ExpencesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
 
            if (ExpencesRadioButton.Checked)
            {
                textBox1.Text = "Витрати";
                SumBox.Text = "-" + SumBox.Text;
            }
            else
            {
                textBox1.Text = "Дохід";
                MessageBox.Show("При введенні значення доходу видаліть символи '-'!");
            }
        }


        private void Sumbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }


        private void додаванняТранзакціїToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Вы не авторизувалися! Авторизуйтесь!");
            }
            else
            {
                panel1.Controls.Clear();
                // Введення суми платежу - створення підпису "Сума:"
                label = new Label();
                label.Text = "Пароль:";
                label.Visible = true;
                label.Location = new Point(100, 100);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                
// Введення суми платежу - створення поля введення імені користувача
                PassConfBox = new TextBox();
                PassConfBox.Visible = true;
                PassConfBox.PasswordChar = '●';
                PassConfBox.Location = new Point(250, 100);
                PassConfBox.Width = 250;
                panel1.Controls.Add(PassConfBox);

                // Введення суми платежу - створення підпису "Сума:"
                label = new Label();
                label.Text = "Сума:";
                label.Visible = true;
                label.Location = new Point(100, 150);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                // Введення суми платежу - створення поля введення імені користувача
                SumBox = new TextBox();
                SumBox.Visible = true;
                SumBox.Location = new Point(250, 150);
                SumBox.Width = 250;
                panel1.Controls.Add(SumBox);
                SumBox.KeyPress += Sumbox_KeyPress;


                // Введення віку користувача - створення підпису "Ваш вік:"
                label = new Label();
                label.Text = "Опис:";
                label.Visible = true;
                label.Location = new Point(100, 200);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);

                // 
                DescriptionBox = new TextBox();
                DescriptionBox.Visible = true;
                DescriptionBox.Location = new Point(250, 200);
                DescriptionBox.Width = 250;
                panel1.Controls.Add(DescriptionBox);

                // Введення суми платежу - створення підпису "Вид транзакції:"
                label = new Label();
                label.Text = "Вид транзакції:";
                label.AutoSize = true;
                label.Visible = true;
                label.Location = new Point(100, 250);
                label.ForeColor = Color.DarkCyan;
                label.Font = LabelFont;
                label.AutoSize = true;
                panel1.Controls.Add(label);
                

                IncomeRadioButton = new RadioButton();
                IncomeRadioButton.Visible = true;
                IncomeRadioButton.Location = new Point(250, 250);
                IncomeRadioButton.AutoSize = true;
                IncomeRadioButton.Text = "Дохід";
                panel1.Controls.Add(IncomeRadioButton);
                IncomeRadioButton.CheckedChanged += new EventHandler(IncomeRadioButton_CheckedChanged);
                //
                ExpencesRadioButton = new RadioButton();
                ExpencesRadioButton.Visible = true;
                ExpencesRadioButton.Location = new Point(500, 250);
                ExpencesRadioButton.AutoSize = true;
                ExpencesRadioButton.Text = "Витрати";
                ExpencesRadioButton.CheckedChanged += new EventHandler(ExpencesRadioButton_CheckedChanged);

                panel1.Controls.Add(ExpencesRadioButton);
                //
                DateTimePicker1 = new DateTimePicker();
                DateTimePicker1.Visible = true;
                DateTimePicker1.Location = new Point(100, 350);
                DateTimePicker1.AutoSize = true;
                DateTimePicker1.Width = 300;
                DateTimePicker1.Font = LabelFont;
                panel1.Controls.Add(DateTimePicker1);
                
                //

                textBox1 = new TextBox();
                textBox1.Visible = false;
                textBox1.Location = new Point(250, 400);
                textBox1.Width = 250;
                panel1.Controls.Add(textBox1);
                panel1.Controls.Add(label);


                // Кнопка "Додати транзакцію"
                AddTransaction = new Button();
                AddTransaction.Text = "Додати транзакцію";
                AddTransaction.Visible = true;
                AddTransaction.Location = new Point(100, 450);
                AddTransaction.AutoSize = true;
                AddTransaction.Font = LabelFont;
                AddTransaction.ForeColor = Color.DarkCyan;
                panel1.Controls.Add(AddTransaction);
                AddTransaction.Click += new EventHandler(AddTransaction_Click);
                if (!string.IsNullOrWhiteSpace(LoginBox.Text) && !string.IsNullOrWhiteSpace(PassBox.Text) && !string.IsNullOrWhiteSpace(SumBox.Text))
                {
                    
                    string query = "SELECT Логін FROM Users_Table";
                    OleDbCommand command = new OleDbCommand(query, myConnection1);
                    OleDbDataReader dbReader = command.ExecuteReader();
                    bool login_isset = false;
                    while (dbReader.Read())
                    {
                        if (LoginBox.Text == dbReader["Логін"].ToString())
                        {
                            login_isset = true;
                        }
                    }

                    if (login_isset)
                    {
                        MessageBox.Show("Користувач із таким логіном вже існує!");
                        реєстраціяToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        // Внесення введених даних в базу даних 

                        string query_ins = $"INSERT INTO Users_Table ([Логін], [Password], [Сума],[Тип транзакції],[Опис]) VALUES ('{LoginBox.Text}', '{PassBox.Text}', '{SumBox.Text}', '{DescriptionBox.Text}')";
                        OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                        int result = command_ins.ExecuteNonQuery();
                        if (result != 0)
                        {
                            MessageBox.Show("Ви успішно зареєструвалися!");
                            вхідToolStripMenuItem_Click(null, null);

                        }
                        else
                        {
                            MessageBox.Show("Виникла помилка під час реєстрації, повторіть спробу!");
                        }
                    }
                }
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myConnection1.Close();
            Close();
        }

        
    }
}
