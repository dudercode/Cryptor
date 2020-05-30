using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnEncrypt_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtString.Text) && !string.IsNullOrEmpty(txtHashKey.Text))
			{
				string result = MD5Utilities.Encrypt(txtString.Text, txtHashKey.Text);
				txtResults.Text = result;
			}
			else
			{
				StringBuilder sb = new StringBuilder("Encryption: ");
				TextBox tb = null;

				if (string.IsNullOrEmpty(txtString.Text))
				{
					sb.Append("String is required. ");
					tb = txtString;
				}

				if (string.IsNullOrEmpty(txtHashKey.Text))
				{
					sb.Append("HashKey is required. ");

					if (tb == null)
					{
						tb = txtHashKey;
					}
				}

				sb.Append("Please try again.");
				HandleError(sb.ToString(), tb);
			}
		}

		private void btnDecrypt_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtString.Text) && !string.IsNullOrEmpty(txtHashKey.Text))
			{
				string result = MD5Utilities.Decrypt(txtString.Text, txtHashKey.Text);
				txtResults.Text = result;
			}
			else
			{
				StringBuilder sb = new StringBuilder("Decryption: ");
				TextBox tb = null;

				if (string.IsNullOrEmpty(txtString.Text))
				{
					sb.Append("String is required. ");
					tb = txtString;
				}

				if (string.IsNullOrEmpty(txtHashKey.Text))
				{
					sb.Append("HashKey is required. ");

					if (tb == null)
					{
						tb = txtHashKey;
					}
				}

				sb.Append("Please try again. ");
				HandleError(sb.ToString(), tb);
			}
		}

		private void HandleError(string msg, TextBox tb)
		{
			lblMessage.Content = msg;
			lblMessage.Foreground = Brushes.Crimson;
			lblMessage.FontWeight = FontWeights.Bold;
			lblMessage.Visibility = Visibility.Visible;
			tb.Focus();
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			txtString.Text = "";
			txtHashKey.Text = "";
			txtResults.Text = "";
			lblMessage.Content = "";
			lblMessage.Foreground = Brushes.Black;
			lblMessage.FontWeight = FontWeights.Normal;
			lblMessage.Visibility = Visibility.Collapsed;
		}
	}
}
