using DiGi.Core;
using DiGi.User.Enums;
using System.Windows;
using System.Windows.Controls;

namespace DiGi.GIS.PostgreSQL.UI.Windows
{
    /// <summary>
    /// Interaction logic for PostgreSQLUserCreateOptionsWindow.xaml
    /// <para>Asks for the user to be created: the email it is keyed by, its optional name, the password it is
    /// authenticated with and the permission level it is granted.</para>
    /// <para>The email and the password are each asked for twice. Neither can be corrected afterwards by anything
    /// this application offers - the email is the natural key of the row, and the password is never stored in a form
    /// anything can read back - so a typo in either produces an account nobody can use.</para>
    /// <para>Unlike the other options windows this one carries no options object. The password reaches it as text,
    /// and an options instance would keep that text alive on the task for the life of the process; the values live
    /// here instead, on a window the task creates, reads and closes within one run.</para>
    /// </summary>
    public partial class PostgreSQLUserCreateOptionsWindow : Window
    {
        private string? email;

        private string? firstName;

        private string? lastName;

        private string? password;

        private UserLevel userLevel = UserLevel.User;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSQLUserCreateOptionsWindow"/> class.
        /// </summary>
        public PostgreSQLUserCreateOptionsWindow()
        {
            InitializeComponent();

            SetUserLevels();
        }

        /// <summary>
        /// Gets the email of the user to create. It carries the value of the control only once the dialog has been closed with OK; until then, and after a cancellation, it is null.
        /// </summary>
        public string? Email
        {
            get
            {
                return email;
            }
        }

        /// <summary>
        /// Gets the optional first name of the user to create, or null when the field was left blank.
        /// </summary>
        public string? FirstName
        {
            get
            {
                return firstName;
            }
        }

        /// <summary>
        /// Gets the optional last name of the user to create, or null when the field was left blank.
        /// </summary>
        public string? LastName
        {
            get
            {
                return lastName;
            }
        }

        /// <summary>
        /// Gets the plain text password the credential is to be derived from. It exists only between the dialog being closed with OK and the credential being derived, and is never written to the database or to a log.
        /// </summary>
        public string? Password
        {
            get
            {
                return password;
            }
        }

        /// <summary>
        /// Gets the permission level to grant the user.
        /// </summary>
        public UserLevel UserLevel
        {
            get
            {
                return userLevel;
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            // Blank reads as "not given" rather than as an empty name, so a skipped optional field leaves the
            // column NULL instead of storing a string that only looks like a value.
            static string? Value(string? text)
            {
                return string.IsNullOrWhiteSpace(text) ? null : text!.Trim();
            }

            string? email_Value = Value(TextBoxControl_Email.Value);
            if (email_Value is null)
            {
                MessageBox.Show("An email has to be given.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // The framework's own parser rather than a pattern of our own: it is what every other part of the
            // system already agrees an address is.
            if (!System.Net.Mail.MailAddress.TryCreate(email_Value, out _))
            {
                MessageBox.Show("The email is not a valid address.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Compared without regard to case because a repetition is a guard against a typo, not a decision about
            // how the address is stored - what is written is what was typed in the first box.
            if (!string.Equals(email_Value, Value(TextBoxControl_EmailRepeat.Value), System.StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The two emails do not match.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string password_Value = PasswordBox_Password.Password;
            if (string.IsNullOrEmpty(password_Value))
            {
                MessageBox.Show("A password has to be given.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Ordinal, and not trimmed: a password is compared exactly as it was typed, so a difference in case or
            // in surrounding space is a difference. The email above can afford to be lenient; this cannot.
            if (!string.Equals(password_Value, PasswordBox_PasswordRepeat.Password, System.StringComparison.Ordinal))
            {
                MessageBox.Show("The two passwords do not match.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // A combo box holds one selection or none, so nothing here has to reject a second one.
            if (ComboBox_UserLevel.SelectedItem is not ComboBoxItem comboBoxItem || comboBoxItem.Tag is not UserLevel userLevel_Value)
            {
                MessageBox.Show("A user level has to be selected.", Title ?? string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            email = email_Value;
            firstName = Value(TextBoxControl_FirstName.Value);
            lastName = Value(TextBoxControl_LastName.Value);
            password = password_Value;
            userLevel = userLevel_Value;

            DialogResult = true;
            Close();
        }

        private void SetUserLevels()
        {
            // Every tier, Guest included: the enum is the list of levels a row may carry, and a level the store
            // accepts but this window cannot set would have to be corrected by hand in SQL.
            foreach (UserLevel userLevel_Item in System.Enum.GetValues<UserLevel>())
            {
                // The value travels in the Tag: the item shows the description, which is what an operator reads,
                // and parsing that text back would tie the selection to the wording of a caption.
                ComboBoxItem comboBoxItem = new()
                {
                    Content = userLevel_Item.Description() ?? userLevel_Item.ToString(),
                    Tag = userLevel_Item
                };

                ComboBox_UserLevel.Items.Add(comboBoxItem);

                if (userLevel_Item == userLevel)
                {
                    ComboBox_UserLevel.SelectedItem = comboBoxItem;
                }
            }
        }
    }
}
