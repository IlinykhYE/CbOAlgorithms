using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CbOAlgorithms.GUI
{
    public partial class Main : Form
    {
        private static string _importFilePath = ""; //путь до импортируемого файла 

        private static readonly string
            TempFilePathWithoutExt =
                "packages/dot/graph"; //относительный путь до временных файлов (png и dot без расширения файла)

        public static Context currentContext; //текущий контекст
        private static Grid _lattice = new Grid(); //концептуальная решётка

        private static bool
            _lastCreateGraphButtonState; //последнее состояние кнопки "Построить граф решётки" о того, как она была заблокирована

        public Main()
        {
            InitializeComponent();
            openFileDialog.Filter = "Excel Worksheets 2007(*.xlsx) | *.xlsx|Excel Worksheets 2003(*.xls) | *.xls";

            //Настройки диалогового окна для сохранения новго файла
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.ValidateNames = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView.Rows.Clear();
                latticeTextBox.Text = "";
                buildConceptButton.Enabled = false;
                CreateGraph.Enabled = false;
                _lastCreateGraphButtonState = false;
                _importFilePath = openFileDialog.FileName;
                toolStripStatusLabel.Text = "Context import...";
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 50;
                importContextBackgroundWorker.RunWorkerAsync(_importFilePath);
            }
        }

        public Main(Context context)
        {
            InitializeComponent();
            openFileDialog.Filter = "Excel Worksheets 2007(*.xlsx) | *.xlsx|Excel Worksheets 2003(*.xls) | *.xls";

            //Настройки диалогового окна для сохранения новго файла
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.ValidateNames = true;

            dataGridView.Rows.Clear();
            currentContext = context;
            var newRows = ShowContext(currentContext);
            dataGridView.ColumnCount = newRows[0].Cells.Count;
            dataGridView.Rows.AddRange(newRows);
            foreach (DataGridViewColumn col in dataGridView.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView.Update();

            editModelCheckBox.Enabled = true;
            editModelCheckBox.Checked = true;
            buildConceptButton.Enabled = false;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            latticeTextBox.Text = "";
            RemoveTempFiles();
        }

        private DataGridViewRow[] ShowContext(Context context)
        {
            var rows = new List<DataGridViewRow>();
            //Добавляем список признаков
            var r = new DataGridViewRow();
            var dg = new DataGridView();
            dg.ColumnCount = context.M.Count + 1;
            var cellsStr = new List<string>();
            cellsStr.AddRange(context.M);
            cellsStr.Insert(0, "");
            r.CreateCells(dg, cellsStr.ToArray());
            rows.Add(r);
            var i = 0;

            //Добавляем бинарную таблицу
            foreach (var row in context.Table)
            {
                r = new DataGridViewRow();
                var tempList = row.ConvertAll(BoolFlagToString);
                tempList.Insert(0, context.G[i]);
                r.CreateCells(dg, tempList.ToArray());
                rows.Add(r);
                i++;
            }

            return rows.ToArray();
        }

        //Конвертер флага в бинарной таблице из bool в string
        private string BoolFlagToString(bool flag)
        {
            return flag ? "x" : "";
        }

        /// <summary>
        ///     Метод удаляет временные файлы прошлого графа
        /// </summary>
        private void RemoveTempFiles()
        {
            try
            {
                File.Delete(TempFilePathWithoutExt + ".png");
                File.Delete(TempFilePathWithoutExt + ".dot");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        ///     Метод выводит на экран текущую концептуальную решётку (вершины)
        /// </summary>
        private void FillLatticeTextBox()
        {
            latticeTextBox.Text = "";
            latticeTextBox.Text = MakeLatticeText(_lattice);
        }

        /// <summary>
        ///     Метод создаёт текстовое описание решётки (вершин решётки)
        /// </summary>
        /// <param name="L">Решётка</param>
        /// <returns></returns>
        private string MakeLatticeText(Grid L)
        {
            var text = L.Verties.Aggregate("{ ", (current, c) => current + (c + Environment.NewLine));
            text = text.TrimEnd('\n').TrimEnd('\r') + " }";
            return text;
        }

        //Событие изменения выбора ячейки
        private void CellSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex == 0 && dataGridView.CurrentCell.RowIndex != 0 &&
                !editModelCheckBox.Checked) removeObjectButton.Enabled = true;
            else removeObjectButton.Enabled = false;
        }

        //Событие изменения галочки "Режим редактирования"
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (editModelCheckBox.Checked)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
                removeObjectButton.Enabled = false;
                buildConceptButton.Enabled = false;
                _lastCreateGraphButtonState = CreateGraph.Enabled;
                CreateGraph.Enabled = false;
            }
            else
            {
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
                removeObjectButton.Enabled = true;
                buildConceptButton.Enabled = true;
                CreateGraph.Enabled = _lastCreateGraphButtonState;
            }
        }

        //Событие нажатия на пукт меню "Закрыть контекст"
        private void OnClickCloseContext(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            editModelCheckBox.Checked = false;
            removeObjectButton.Enabled = false;
            buildConceptButton.Enabled = false;
            _lastCreateGraphButtonState = CreateGraph.Enabled;
            CreateGraph.Enabled = false;
            latticeTextBox.Text = "";
            currentContext = null;
        }


        //Событие окончания редактирования значения в ячейке
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _lastCreateGraphButtonState = false;
        }

        //Событие двойного нажатия мышкой на ячейку
        private void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _lastCreateGraphButtonState = false;
            var cell = ((DataGridView) sender).SelectedCells[0];
            if (cell.RowIndex <= 0 || cell.ColumnIndex <= 0 || editModelCheckBox.Checked != true) return;
            if (cell.Value == null)
            {
                //Изменяем значение в бинарной таблице контекста
                currentContext.Table[cell.RowIndex - 1][cell.ColumnIndex - 1] = true;
                cell.Value = "x";
            }
            else
            {
                //Изменяем значение в бинарной таблице контекста
                currentContext.Table[cell.RowIndex - 1][cell.ColumnIndex - 1] = false;
                cell.Value = null;
            }
        }

        //Событие нажатия мышкой на ячейку
        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CellDoubleClick(sender, new DataGridViewCellEventArgs(e.RowIndex, e.ColumnIndex));
            }
        }

        //Событие нажатия на кнопку "Построить концепт"
        private void OnClickBuildConceptButton(object sender, EventArgs e)
        {
            latticeTextBox.Text = "";
            buildConceptButton.Enabled = false;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            toolStripStatusLabel.Text = "Создание решётки...";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
            //Запускаем фоновый процесс создания концептуальной решётки из контекста
            createLatticeBackgroundWorker.RunWorkerAsync();
        }

        //Событие нажатия на кнопку "Построить граф решётки"
        private void OnClickCreateGraphButton(object sender, EventArgs e)
        {
            try
            {
                //Graph latticeGraph = new Graph(Lattice, currentContext);
                //latticeGraph.SavePng(tempFilePathWithoutExt, true);
                _lattice.SavePng(TempFilePathWithoutExt, true);
                //Lattice.SaveSvg(tempFilePathWithoutExt);
                var window = new ShowGraphWindow(TempFilePathWithoutExt);
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания изображения! \nПодробнее:\n" + ex.Message, "Ошибка");
            }
        }

        //Событие закрытие программы
        private void OnCloseMainForm(object sender, FormClosingEventArgs e)
        {
            //Уточняем, хочет ли пользователь сохранить решётку, если она построена
            if (latticeTextBox.Text != "")
            {
                var res = MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение изменений",
                    MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true; // отменяем закрытие формы
                        break;
                    case DialogResult.Yes:
                    {
                        var window = new SaveChangesForm();
                        if (window.ShowDialog() == DialogResult.OK)
                        {
                            //Сохраняем выбранные файлы
                            //txt-файл с решёткой
                            if (window.saveLattice)
                            {
                                saveFileDialog.Filter = "Text Files (*.txt) | *.txt";
                                saveFileDialog.DefaultExt = "txt";
                                saveFileDialog.FileName = "lattice.txt";
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    var fs = File.Create(saveFileDialog.FileName);
                                    fs.Close();
                                    File.WriteAllText(saveFileDialog.FileName, latticeTextBox.Text);
                                }
                            }

                            //png-файл графа
                            if (window.savePng)
                            {
                                saveFileDialog.Filter = "Image Files (*.png) | *.png";
                                saveFileDialog.DefaultExt = "png";
                                saveFileDialog.FileName = "graph.png";
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    //Проверяем, были ли созданы временные файлы графа
                                    if (!File.Exists(TempFilePathWithoutExt + ".png"))
                                    {
                                        //Если нет, создаём
                                        var latticeGraph = new Grid(Algorithms.CloseByOne(currentContext),
                                            currentContext);
                                        latticeGraph.SavePng(TempFilePathWithoutExt, true);
                                    }

                                    //Копируем файл из временного хранилища в указанное пользователем
                                    File.Copy(TempFilePathWithoutExt + ".png", saveFileDialog.FileName, true);
                                }
                            }

                            //dot-файл графа
                            if (window.saveDot)
                            {
                                saveFileDialog.Filter = "Dot Files (*.dot) | *.dot";
                                saveFileDialog.DefaultExt = "dot";
                                saveFileDialog.FileName = "graph.dot";
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    //Проверяем, были ли созданы временные файлы графа
                                    if (!File.Exists(TempFilePathWithoutExt + ".dot"))
                                    {
                                        //Если нет, создаём
                                        var latticeGraph = new Grid(Algorithms.CloseByOne(currentContext),
                                            currentContext);
                                        latticeGraph.SavePng(TempFilePathWithoutExt, true);
                                    }

                                    //Копируем файл из временного хранилища в указанное пользователем
                                    File.Copy(TempFilePathWithoutExt + ".dot", saveFileDialog.FileName, true);
                                }
                            }
                        }

                        break;
                    }
                }
            }

            //Удаляем временные файлы
            RemoveTempFiles();
        }

        //Событие выбора Файл -> Выход
        private void OnClickExit(object sender, EventArgs e)
        {
            Close();
        }


        //Событие нажатия клавиши, когда выделена ячейка таблицы
        private void OnKeyPressWithSelectedCell(object sender, KeyPressEventArgs e)
        {
            //Если нажата клавиша пробел и есть выделенная ячейка
            if (e.KeyChar != ' ' || ((DataGridView) sender).SelectedCells.Count != 1) return;
            var cell = ((DataGridView) sender).SelectedCells[0];
            //Проверяем, что выделенная ячейка не находится в столбце объектов или строке признаков
            if (cell.RowIndex <= 0 || cell.ColumnIndex <= 0) return;
            try
            {
                switch (cell.Value.ToString())
                {
                    //Проверяем значение в ячейке и меняем на противоположное
                    case "x":
                        cell.Value = "";
                        break;
                    case "":
                        cell.Value = "x";
                        break;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        //Работа, выполняемая importContextBackgroundWorker
        private void bw_DoWork_importContext(object sender, DoWorkEventArgs e)
        {
            //Получаем путь о импортируемого файла
            //Выполняем импорт файла
            currentContext = new Context(_importFilePath);
            //Подготавливаем и выводим на экран полученный контекст
            importContextBackgroundWorker.ReportProgress(50);
            e.Result = ShowContext(currentContext);
            importContextBackgroundWorker.ReportProgress(100);
        }

        //Реакция на прогресс importContextBackgroundWorker
        private void Bw_ProgressChanged_importContext(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 50) return;
            toolStripStatusLabel.Text = "Creating context...";
            dataGridView.Rows.Clear(); //Очищаем таблицу
        }

        //Завершение работы importContextBackgroundWorker
        private void bw_RunWorkerCompleted_importContext(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Debug.WriteLine("BackgroundWorker stoped by user!");
            else if (e.Error != null)
                MessageBox.Show(
                    "Ошибка загрузки файла! \nВозможно, импортируемый файл имеет неправильный формат или тип файла.\n\nПодробнее о формате файла импорта можно прочесть по ссылке под кнопкой импорта. \n\nОшибка: " +
                    e.Error);
            else
            {
                var newRows = (DataGridViewRow[]) e.Result;
                dataGridView.ColumnCount = newRows[0].Cells.Count;
                dataGridView.Rows.AddRange(newRows);
                foreach (DataGridViewColumn col in dataGridView.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                dataGridView.Update();
            }

            toolStripStatusLabel.Text = "Done";
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Visible = false;
            buildConceptButton.Enabled = true;
        }



        //Работа, выполняемая createLatticeBackgroundWorker
        private void createLatticeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var L = new Grid(Algorithms.CloseByOne(currentContext), currentContext);
            var text = MakeLatticeText(L);
            e.Result = new object[] {L, text};
        }

        //Завершение работы createLatticeBackgroundWorker
        private void createLatticeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Debug.WriteLine("BackgroundWorker stoped by user!");
            else if (e.Error != null)
                MessageBox.Show("Can`t create the cell! \n\nMore: " + e.Error);
            else
            {
                _lattice = (Grid) ((object[]) e.Result)[0];
                latticeTextBox.Text = (string) ((object[]) e.Result)[1];
            }

            _lastCreateGraphButtonState = true;
            CreateGraph.Enabled = true;
            toolStripStatusLabel.Text = "Done";
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Visible = false;
            buildConceptButton.Enabled = true;
        }

        //Работа, выполняемая createLatticeCbOV1BackgroundWorker
        private void createLatticeCbOV1BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var L = new Grid(Algorithms.CloseByOneV1(currentContext), currentContext);
            var text = MakeLatticeText(L);
            e.Result = new object[] { L, text };
        }

        //Работа, выполняемая createLatticeLCMWithoutPruningBackgroundWorker
        private void createLatticeLCMWithoutPruningBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var L = new Grid(Algorithms.LCMWithoutPruning(currentContext), currentContext);
            var text = MakeLatticeText(L);
            e.Result = new object[] { L, text };
        }

        private void CreateContextHandlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createContextWindow = new CreateContext();
            createContextWindow.ShowDialog();
            if (createContextWindow.DialogResult != DialogResult.OK) return;
            dataGridView.Rows.Clear();
            currentContext = new Context(createContextWindow.objectCount, createContextWindow.attributeCount);
            var newRows = ShowContext(currentContext);
            dataGridView.ColumnCount = newRows[0].Cells.Count;
            dataGridView.Rows.AddRange(newRows);
            foreach (DataGridViewColumn col in dataGridView.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView.Update();

            editModelCheckBox.Enabled = true;
            editModelCheckBox.Checked = true;
            buildConceptButton.Enabled = false;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            latticeTextBox.Text = "";
            RemoveTempFiles();
        }

        private void ImportContextFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            dataGridView.Rows.Clear();
            latticeTextBox.Text = "";
            buildConceptButton.Enabled = false;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            _importFilePath = openFileDialog.FileName;
            toolStripStatusLabel.Text = "Импорт контекста...";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
            //Запускаем фоновый процесс загрузки контекста из файла
            importContextBackgroundWorker.RunWorkerAsync(_importFilePath);
        }

        private void CreateRandomContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createContextWindow = new CreateContext();
            createContextWindow.ShowDialog();
            if (createContextWindow.DialogResult != DialogResult.OK) return;
            dataGridView.Rows.Clear();
            currentContext =
                Context.RandomContext(createContextWindow.objectCount, createContextWindow.attributeCount, 0.8);
            var newRows = ShowContext(currentContext);
            dataGridView.ColumnCount = newRows[0].Cells.Count;
            dataGridView.Rows.AddRange(newRows);
            foreach (DataGridViewColumn col in dataGridView.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView.Update();

            editModelCheckBox.Enabled = false;
            editModelCheckBox.Checked = false;
            buildConceptButton.Enabled = true;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            latticeTextBox.Text = "";
            RemoveTempFiles();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Создание контекста CbO ver 1.
        private void button1_Click(object sender, EventArgs e)
        {
            latticeTextBox.Text = "";
            buildConceptButton.Enabled = false;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            toolStripStatusLabel.Text = "CbO V1";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
            //Запускаем фоновый процесс создания концептуальной решётки из контекста
            createLatticeCbOV1BackgroundWorker.RunWorkerAsync();
        }

        private void LCM_Click(object sender, EventArgs e)
        {
            latticeTextBox.Text = "";
            buildConceptButton.Enabled = true;
            CreateGraph.Enabled = false;
            _lastCreateGraphButtonState = false;
            toolStripStatusLabel.Text = "LCM";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
            //Запускаем фоновый процесс создания концептуальной решётки из контекста
            createLatticeLCMBackgroundWorker.RunWorkerAsync();
        }
    }
}