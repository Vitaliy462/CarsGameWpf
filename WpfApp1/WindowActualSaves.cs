using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using WpfApp1.DB;
using WpfApp1.model;

namespace WpfApp1
{
    public partial class WindowActualSaves : Window
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        private int allRows = 0;
        static int k = 0;
        //public List<int> A = new List<int>();
        public override void EndInit()
        {
            //foreach (Car car in unitOfWork.Cars.getAll())
            // {
            //    A.Add(car.Id);
            //}
            foreach (Car car in unitOfWork.Cars.getAll())
            {
                AddToTable(car.Id);
                allRows += 1;
            }
            ////Console.WriteLine(allRows);
            base.EndInit();

        }



        private void AddNew(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            unitOfWork.SavePlayer(player);

            AddToTable(player.Id_Car);
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {

            RemoveFromTable();
        }
        private void AddToTable(int car_id)
        {
            Player player = unitOfWork.LoadPlayerByCarId(car_id);
            if (player != null)
            {
                TableRowGroup o = new TableRowGroup();
                TableRow tr = new TableRow();
                tr.Cells.Add(Make(player.Id.ToString()));
                tr.Cells.Add(Make(player.Id_Car.ToString()));
                tr.Cells.Add(Make(player.GetCar().GetAccum()?.ToString()));
                tr.Cells.Add(Make(player.GetCar().GetEngine()?.ToString()));
                tr.Cells.Add(Make(player.GetCar().GetDisk()?.ToString()));
                tr.Cells.Add(Make(player.Money.ToString()));
                tr.Cells.Add(Make(player.Km.ToString()));
                o.Rows.Add(tr);
                mytable.RowGroups.Add(o);
                k++;
            }
        }

        private void RemoveFromTable()
        {

            //for (int i = 0; i < tr.Cells.Count; i++)
            //{
            //for (int i = 0; i < allRows; i++)
            //{
            //    foreach(TableCell tc in tr.Cells)
            //    {
            //        tr.Cells.Remove(tc);
            //    }
            //mytable.E
            for (int i = 1; i < mytable.RowGroups.Count; i++)
            {
                var group = mytable.RowGroups.ElementAt(1);
                var row = group.Rows.ElementAt(0);
                var cell = row.Cells.ElementAt(0);
                Paragraph content = (Paragraph)cell.Blocks.FirstBlock;
                Run item = (Run)content.Inlines.First();
                Console.WriteLine(item.Text);
                unitOfWork.DeletePlayerById(Convert.ToInt32(item.Text));
                mytable.RowGroups.Remove(group);
            }

            //foreach (Player player in unitOfWork.Players.getAll())
            //{
            //    TableRowGroup o = new TableRowGroup();
            //    TableRow tr = new TableRow();
            //    _ = tr.Cells.Remove(Remove(player.Id.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.Id_Car.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.GetCar().GetAccum()?.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.GetCar().GetEngine()?.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.GetCar().GetDisk()?.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.Money.ToString()));
            //    _ = tr.Cells.Remove(Remove(player.Km.ToString()));
            //    o.Rows.Remove(tr);
            //    mytable.RowGroups.Remove(o);
            //    Console.WriteLine(player.Id);
            //}
            //foreach(TableRow row in o.Rows)
            // {
            //     o.Rows.Remove(row);
            // }
            //foreach (TableRowGroup row in mytable.RowGroups)
            //{
            //    mytable.RowGroups.Remove(row);
            //}
            
        }


        // _ = o.Rows.Remove(tr);

        //tr.Cells.Re(5,1);
        //}

        

       
        private TableCell Make(string data)
        {
            TableCell tc = new TableCell();
            tc.BorderBrush = Brushes.Black;
            tc.BorderThickness = new Thickness(1, 1, 1, 1);
            tc.Blocks.Add(new Paragraph(new Run(data)));
            return tc;
        }
    }
}

