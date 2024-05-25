using System;
using System.Diagnostics;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Konwerter_C__Python
{
    public class SimpleTextEditorForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private TextBox inputTextBox;
        private TextBox outputTextBox;
        private TextBox execTextBox;
        private Button actionButton;

        public SimpleTextEditorForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Ustawienia okna
            this.Text = "Konwerter C na Python";
            this.FormBorderStyle = FormBorderStyle.Sizable; // Zapobiega zmianie rozmiaru okna
             // Wyłącza przycisk "maximize"

            // Tworzymy TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill; // Wypełnij całe okno
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            tableLayoutPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(tableLayoutPanel);

            // Pole do wpisywania tekstu
            inputTextBox = new TextBox();
            inputTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            inputTextBox.Multiline = true;
            inputTextBox.AcceptsReturn = true;
            inputTextBox.ScrollBars = ScrollBars.Vertical;
            tableLayoutPanel.Controls.Add(inputTextBox, 0, 0);

            // Pole do odczytywania tekstu
            outputTextBox = new TextBox();
            outputTextBox.ReadOnly = true; // Ustaw pole jako tylko do odczytu
            outputTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            outputTextBox.Multiline = true;
            outputTextBox.ScrollBars = ScrollBars.Vertical;
            tableLayoutPanel.Controls.Add(outputTextBox, 1, 0);

            execTextBox = new TextBox();
            execTextBox.ReadOnly = true; // Ustaw pole jako tylko do odczytu
            execTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            execTextBox.Multiline = true;
            execTextBox.ScrollBars = ScrollBars.Vertical;
            tableLayoutPanel.Controls.Add(execTextBox, 2, 0);

            // Przycisk
            actionButton = new Button();
            actionButton.Text = "Przekonwertuj i wykonaj";
            actionButton.Anchor = AnchorStyles.Bottom;
            actionButton.MinimumSize = new System.Drawing.Size(200, 100);
            tableLayoutPanel.Controls.Add(actionButton, 0, 1);
            actionButton.Click += ButtonClick;

            this.Size = new System.Drawing.Size(1600, 800);
            this.MaximizeBox = false;

            // Ustawiamy rozciągliwość kolumny drugiej
            // tableLayoutPanel.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 100); // Druga kolumna ma stałą szerokość 100 pikseli
        }

        public void ButtonClick(object? sender, EventArgs e) {
            try {
                string input = inputTextBox.Text;
                ICharStream stream = CharStreams.fromString(input);
                ITokenSource lexer = new CGrammarLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                CGrammarParser parser = new CGrammarParser(tokens);
                PythonGenerator visitor = new PythonGenerator();
                PythonGenerator.error = null;
                parser.RemoveErrorListeners();
                parser.AddErrorListener(new ThrowingErrorListener());
                IParseTree tree = parser.program();
                string pythonCode = visitor.Visit(tree);

                if(PythonGenerator.error == null) {
                    File.WriteAllText("script.py", pythonCode);
                    outputTextBox.Lines = pythonCode.Split("\n");

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "python";
                    startInfo.Arguments = "script.py";
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    using(Process process = Process.Start(startInfo)!)
                    {
                        using(StreamReader reader = process.StandardOutput)
                        {
                            string result1 = reader.ReadToEnd();
                            execTextBox.Lines = result1.Split('\n');
                        }
                    }
                    execTextBox.Focus();
                    execTextBox.SelectionStart = execTextBox.Text.Length;
                    execTextBox.ScrollToCaret();
                }
                else {
                    outputTextBox.Text = PythonGenerator.error;
                    execTextBox.Text = "";
                }
                
            }
            catch(Exception ) {
                outputTextBox.Text = "Błędny kod!";
                execTextBox.Text = "";
            }
        }

        // Główna metoda uruchamiająca aplikację
        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.SetCompatibleTextRenderingDefault(false);
        //     Application.Run(new SimpleTextEditorForm());
        // }
    }
}