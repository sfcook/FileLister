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

namespace FileLister
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string instructions = "Drag and drop files here.";
		HashSet<string> files = new HashSet<string>(); //unique list of files

		public MainWindow()
		{
			InitializeComponent();

			tbxList.Text = instructions;
		}

		private void tbxListDrop(object sender, DragEventArgs e)
		{
			string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string str in paths)
			{
				files.Add(str);
			}

			tbxList.Text = "";
			foreach (string str in files)
			{
				tbxList.Text += str + "\n";
			}
		}

		private void tbxListDrag(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effects = DragDropEffects.All;
				e.Handled = true; //important
			}
			else
			{
				e.Effects = DragDropEffects.None;
			}
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			tbxList.Text = instructions;
			files.Clear();
		}

		private void btnClip_Click(object sender, RoutedEventArgs e)
		{
			if (tbxList.Text != instructions)
			{
				Clipboard.SetData(DataFormats.Text, (Object)tbxList.Text);
			}
		}
	}
}
