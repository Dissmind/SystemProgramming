using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;


namespace lab10_var3
{
    /// <summary>
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        public AddNote()
        {
            InitializeComponent();
        }


        private void Button_Click_AddNote(object sender, RoutedEventArgs e)
        {
            if (!CheckData())
            {
                return;
            }


            MessageBoxButton modalConfirm = MessageBoxButton.YesNo;
            MessageBoxResult modalConfirmResult = MessageBox.Show("Вы хотите добавить новую запись в базу?", "Добавление записи", modalConfirm);

            if (modalConfirmResult == MessageBoxResult.Yes)
            {
                var model = new MedModel();

                model.Id = Int32.Parse(Id.Text);
                model.Name = Name.Text;
                model.Adress = Adres.Text;
                model.Type = Type.Text;
                model.Description = Description.Text;

                Repository.Add(model);

                MessageBox.Show($"Запись с именем {Name.Text} - успешно добавленная в базу!");

                this.Hide();
            }
        }


        private bool CheckData()
        {

            // Check id input
            if (FormatVerification.IsEmpty(Id.Text))
            {
                MessageBox.Show("Поле код должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.SpaceCheck(Id.Text))
            {
                MessageBox.Show("Поле код не должно иметь пробелы!");

                return false;
            }
            else if (FormatVerification.IsDigital(Id.Text))
            {
                MessageBox.Show("Поле код должно состоять только из чисел!");

                return false;
            }
            else
            {
                var list = Repository.GetAllId();

                foreach (var i in list)
                {
                    if (i == Id.Text)
                    {
                        MessageBox.Show("Запись с таким кодом уже существует");

                        return false;
                    }
                }
            }


            // Check name input
            if (FormatVerification.IsEmpty(Name.Text))
            {
                MessageBox.Show("Поле имя должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.SpaceCheck(Name.Text))
            {
                MessageBox.Show("Поле имя не должно иметь пробелы!");

                return false;
            }
            else
            {
                var list = Repository.GetAllName();

                foreach (var i in list)
                {
                    if (i == Name.Text)
                    {
                        MessageBox.Show("Запись с таким именем уже существует");

                        return false;
                    }
                }
            }


            // Check type input
            if (FormatVerification.IsEmpty(Type.Text))
            {
                MessageBox.Show("Тип должен быть выбран!");

                return false;
            }

            return true;
        }
    }
}
