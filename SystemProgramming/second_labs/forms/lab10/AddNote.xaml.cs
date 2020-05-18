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
                var note = new NoteModel();

                note.Name        = Name.Text;
                note.Price       = Int32.Parse(Price.Text);
                note.Type        = Type.Text;
                note.InCredit    = InCredit.IsChecked.Value;
                note.Description = Description.Text;

                Repository.Add(note);

                MessageBox.Show($"Запись с именем {Name.Text} - успешно добавленная в базу!");

                this.Hide();
            }
        }


        private bool CheckData()
        {
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
            else if (!FormatVerification.IsDigital(Name.Text[0].ToString()))
            {
                MessageBox.Show("Поле имя не должно начинаться с цифры!");

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


            // Check price input
            if (FormatVerification.IsEmpty(Price.Text))
            {
                MessageBox.Show("Поле цена должно быть заполненно!");

                return false;
            }
            else if (FormatVerification.IsDigital(Price.Text))
            {
                MessageBox.Show("Поле цена должно содержать только числа!");

                return false;
            }
            else if (Int32.Parse(Price.Text) < 0)
            {
                MessageBox.Show("Цена не должна быть меньше 0");

                return false;
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
