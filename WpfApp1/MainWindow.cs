using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.DB;
using WpfApp1.model;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Player player       = null;
        private Detail pureDetail   = null;
        private Detail advDetail    = null;
        private Detail proDetail    = null;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private void ButtonStart(object sender, RoutedEventArgs e)
        {
            player = new Player();
            UpdateUI();
            panelGame.Visibility = Visibility.Visible;
        }
        private void Button1(object sender, RoutedEventArgs e)
        {
            //unitOfWork.Engines.Create(DetailFactory.GetAdvEngine());
            unitOfWork.SavePlayer(player);
        }

        private void Button2(object sender, RoutedEventArgs e)
        {
            //foreach (Engine engine in unitOfWork.Engines.getAll())
            //{
            //    Console.WriteLine(engine);
            //    Console.WriteLine("------");
            //}
            player = unitOfWork.LoadLastPlayer();
            UpdateUI();
        }

        private void OpenSaves(object sender, RoutedEventArgs e)
        {
            WindowActualSaves window = new WindowActualSaves();
            window.Show();
        }
        private void ButtonRepair(object sender, RoutedEventArgs e)
        {
            player.RepairTotal();
            UpdateUI();
        }
        void UpdateUI()
        {
            money.Content = player.Money + " $";
            drived.Content = player.Km + " km";
            carInfo.Content =  "Info:\n" + player.ShowCarInfo();
            repair.Visibility = Visibility.Hidden;
            if (!player.GetCar().IsInited())
            {
                
                ShowShop();
            }
            else if (player.CanRepair())
            {
                ShowShop();
                repair.Visibility = Visibility.Visible;
                repair.Content = "repair " + player.CalculateRepairCost() + "$";
            }
            else
            {
                repair.Visibility = Visibility.Hidden;
                shop.Visibility = Visibility.Hidden;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            player.Update();
            UpdateUI();
            if (!player.GetCar().CanDrive())
            {
                timer.Stop();
            }

        }
        private void Button_Drive(object sender, RoutedEventArgs e)
        {
            timer.Start();
            //while(player.car.CanDrive())
            //{
            //    player.Update();
            //    UpdateUI();
            //    Thread.Sleep(1000);
            //}
        }

        
        public bool PrepareDetails()
        {
            if(player.GetCar().NeedDetail(model.Detail.DetailType.DISK))
            {
                pureDetail  = DetailFactory.GetSimpleDisk();
                advDetail   = DetailFactory.GetAdvDisk();
                proDetail   = DetailFactory.GetProDisk();
                return true;
            }
            else if (player.GetCar().NeedDetail(model.Detail.DetailType.ACCUMULATOR))
            {
                pureDetail = DetailFactory.GetSimpleAccum();
                advDetail = DetailFactory.GetAdvAccum();
                proDetail = DetailFactory.GetProAccum();
                return true;
            }
            else if (player.GetCar().NeedDetail(model.Detail.DetailType.ENGINE))
            {
                pureDetail = DetailFactory.GetSimpleEngine();
                advDetail = DetailFactory.GetAdvEngine();
                proDetail = DetailFactory.GetProEngine();
                return true;
            }
            return false;
        }
        public void ViewDetails()
        {
            shop.Visibility = Visibility.Visible;

            item1.Content = "Buy " + pureDetail.Cost + "$";
            item2.Content = "Buy " + advDetail.Cost + "$";
            item3.Content = "Buy " + proDetail.Cost + "$";

            item1Desc.Content = pureDetail.ToString();
            item2Desc.Content = advDetail.ToString();
            item3Desc.Content = proDetail.ToString();

        }


        public void ShowShop()
        {
            if (PrepareDetails())
            {
                ViewDetails();
            }
            else
            {
                shop.Visibility = Visibility.Hidden;
            }
        }
        private void BuyDetail(object sender, RoutedEventArgs e)
        {
            if(sender == item1)
            {
                player.BuyDetail(pureDetail);
            }
            if (sender == item2)
            {
                player.BuyDetail(advDetail);
            }
            if (sender == item3)
            {
                player.BuyDetail(proDetail);
            }
            ShowShop();
            UpdateUI();
        }
        
    }


}
