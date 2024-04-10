using Lab2.Calculation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lab2.UI
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            MinimumSize = Size;
            MaximumSize = Size;
            MaximizeBox = false;
            string indexPath = System.IO.Path.Combine(Application.StartupPath, "UI", "Desmos", "index.html");
            graph.Source = new Uri(indexPath);
        }

        private void inputGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RerenderButton();
        }

        private void RerenderButton()
        {
            calculateButton.Enabled = CheckCalculability();
        }
        private bool CheckCalculability()
        {
            if (inputGrid.Rows.Count < 9) return false;
            if (inputGrid.Rows.Count > 13) return false;
            return true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Открыть файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(filePath);
                    inputGrid.Rows.Clear();
                    foreach (string line in lines)
                    {
                        string[] splitted = line.Split(' ');
                        inputGrid.Rows.Add(new object[] { splitted[0], splitted[1] });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void calculateButton_Click(object sender, EventArgs e)
        {
            Dictionary<double, double> input = new Dictionary<double, double>();
            foreach(DataGridViewRow row in inputGrid.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    continue;
                string x = row.Cells[0].Value.ToString();
                string y = row.Cells[1].Value.ToString();
                if(!IsDoubleValid(x) || !IsDoubleValid(y))
                {
                    MessageBox.Show($"Обнаружено неверное значение в строке {row.Index + 1}");
                    return;
                }
                if(input.ContainsKey(ParseDouble(x)))
                {
                    MessageBox.Show($"Дубликат значения X в строке №{row.Index + 1}");
                    return;
                }
                input.Add(ParseDouble(x), ParseDouble(y));
            }
            if(input.Count < 8 || input.Count > 12)
            {
                MessageBox.Show($"Необходимо ввести от 8 до 12 строк");
                return;
            }
            outputGrid.Rows.Clear();
            await graph.CoreWebView2.ExecuteScriptAsync($"setBounds({input.Keys.Min()}, {input.Keys.Max()})");
            await graph.CoreWebView2.ExecuteScriptAsync($"clear()");
            (OutputTable[] result, int index) = Approximation.Calculate(new InputTable(input));
            string label = "Результат:\n" +
                $"Выбрана {NameFromInt(index)} функция.\n" +
                $"Достоверность R² = {FormatNumber(Utils.CalculateTrust(result[index]))}\n";
            for(int i = 0; i < result.Length; i++)
            {
                label += NameFromInt(i) + $" - " +
                    $"Коэфф-ы: {string.Join(", ", Array.ConvertAll(result[i].Coefficients, x => FormatNumber(x)))}. " +
                    $"СКО: {FormatNumber(Utils.CalculateMidsquareDeviation(result[i]))}. ";
                if (i == 0) label += $"К. Пирсона: {FormatNumber(Utils.CalculatePirson(new InputTable(input)))}";
                if(i != index)
                    await graph.CoreWebView2.ExecuteScriptAsync($"expressionShadow('{result[i].Equation.Latex}', {i})");
                else
                {
                    await graph.CoreWebView2.ExecuteScriptAsync($"expression('{result[i].Equation.Latex}', {i})");
                    foreach (double key in result[i].Table.Keys)
                    {
                        OutputRow row = result[i].Table[key];
                        outputGrid.Rows.Add(new object[] { row.Phi, row.Epsilon });
                    }
                }
                label += "\n";
            }
            resultLabel.Text = label;
        }
        public string NameFromInt(int i)
        {
            if (i == 0) return "Линейная";
            if (i == 1) return "Степенная";
            if (i == 2) return "Экспонента";
            if (i == 3) return "Логарифм";
            if (i == 4) return "Квадратичная";
            return "???";
        }
        public bool IsDoubleValid(string text)
        {
            return double.TryParse(text.Replace(".", ","), out double result);
        }
        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace(".", ","));
        }
        public static string FormatNumber(double number)
        {
            if (number.ToString().Contains("E"))
            {
                string[] parts = number.ToString().Split('E');
                double coefficient = double.Parse(parts[0]);
                int exponent = int.Parse(parts[1]);

                return $"{coefficient} · 10^({exponent})";
            }

            return number.ToString();
        }

        private void inputGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            RerenderButton();
        }
        private void inputGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RerenderButton();
        }
    }
}
