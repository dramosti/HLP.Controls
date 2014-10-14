using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HLP.Controls.Static
{
    public static class Util
    {
        public static bool IsDesignTime()
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
        }

        public static object ExecuteMethodByReflection(string xNamespace, string xType, string xMethod, object[] parameters)
        {
            Type t = GetTypeByReflection(xNamespace: xNamespace, xType: xType);

            if (t != null)
            {
                MethodInfo method = t.GetMethod(name: xMethod);

                if (method != null)
                    return method.Invoke(obj: t, parameters: parameters);
            }

            return null;
        }

        public static Type GetTypeByReflection(string xNamespace, string xType)
        {
            Type t = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (assemblies != null)
            {
                Assembly selectedAssembly = assemblies.ToList().FirstOrDefault(
                    i => i.ManifestModule.Name.StartsWith(value: xNamespace));

                if (selectedAssembly != null)
                    t = selectedAssembly.GetTypes().FirstOrDefault(i => i.Name == xType);
            }

            return t;
        }

        public static TipoConexao EmRedeLocal()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr;

            try
            {
                string xIpServidor = ConfigurationSettings.AppSettings.Get(name: "ipServidor");

                if (!string.IsNullOrEmpty(value: xIpServidor))
                {
                    pr = p.Send(xIpServidor);

                    if ((pr.Status == System.Net.NetworkInformation.IPStatus.Success))
                        return TipoConexao.enumRede;
                }

                InternetCS verificaInternet = new InternetCS();

                if (verificaInternet.Conexao())
                    return TipoConexao.enumInternet;

                return TipoConexao.enumOff;
            }
            catch (Exception)
            {
                return TipoConexao.enumOff;
            }
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public static System.Windows.Controls.DataGridCell GetCell(this System.Windows.Controls.DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = Util.GetVisualChild<DataGridCellsPresenter>(row);
                System.Windows.Controls.DataGridCell cell = null;

                if (presenter != null)
                    cell =
                        (System.Windows.Controls.DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj, Type type) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    if (child.GetType() != typeof(DataGrid) && child.GetType() != type)
                    {
                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        public static Point GetBottomPositionComponentInMainWindow(FrameworkElement comp, double addHeight = 0)
        {
            Point relativePoint = comp.TransformToAncestor(Application.Current.MainWindow)
                .Transform(new Point(0, 0));

            double titleHeight = SystemParameters.WindowCaptionHeight + SystemParameters.ResizeFrameHorizontalBorderHeight;
            double verticalBorderWidth = SystemParameters.ResizeFrameVerticalBorderWidth;

            double newY = relativePoint.Y + (Application.Current.MainWindow.WindowState == WindowState.Maximized ? 0 : Application.Current.MainWindow.Top)
                + titleHeight + verticalBorderWidth + (Double.IsNaN(comp.Height) ? addHeight : comp.Height);

            double newX = relativePoint.X +
                (Application.Current.MainWindow.WindowState == WindowState.Maximized ? 0 : Application.Current.MainWindow.Left)
                + verticalBorderWidth;

            return new Point(x: newX, y: newY);
        }
    }
}
