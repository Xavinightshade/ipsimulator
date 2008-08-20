using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SourceGrid.Cells.Views;
using System.Threading;

namespace dockSample
{
    public partial class Prueba : DockContent
    {
        public Prueba()
        {
            InitializeComponent();
        
           
        }
        private IView _vista = new CellBackColorAlternate(Color.White, Color.WhiteSmoke);
        private delegate void SetLabelTextDelegate(string type, string description);
        public void AddLog(string type, string description)
        {
            if (this.InvokeRequired)
            {
                // Pass the same function to BeginInvoke,
                // but the call would come on the correct
                // thread and InvokeRequired will be false.
                this.BeginInvoke(new SetLabelTextDelegate(AddLog),
                                                            new object[] { type, description });

                return;
            }
            int row = 1;
            grid.Rows.Insert(row);
            
            grid[row, 0] = new SourceGrid.Cells.Cell(DateTime.Now);
            grid[row, 1] = new SourceGrid.Cells.Cell(type);
            grid[row, 2] = new SourceGrid.Cells.Cell(description);
            grid[row, 0].View = _vista;
            grid[row, 1].View = _vista;
            grid[row, 2].View = _vista;
       
          //  grid.Selection.ResetSelection(false);
           // grid.Selection.SelectRow(row, true);
          //  grid.Selection.FocusRow(1);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            grid.Redim(1, 3);

            grid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            grid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

            grid.FixedRows = 1;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("Date");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("Type");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Description");

            grid.AutoStretchColumnsToFitWidth = true;
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;

            AddLog("Log", "Application Started");


            for (int i = 0; i < 3; i++)
            {
               
                AddLog("Log", "Application test " + i.ToString());
            }

            grid.Columns.AutoSize(true);
            grid.Columns.StretchToFit();
        }
        Thread t;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (t == null)
            {
                t = new Thread(Hola);
                t.Start();
            }

        }
        private void Hola()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(4);
                AddLog("Log", "Application test " + i.ToString());
            }
        }
    }
    public class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
    {
        public CellBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }

        private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        {
            get { return mFirstBackground; }
            set { mFirstBackground = value; }
        }

        private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        {
            get { return mSecondBackground; }
            set { mSecondBackground = value; }
        }

        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);

            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }
}
