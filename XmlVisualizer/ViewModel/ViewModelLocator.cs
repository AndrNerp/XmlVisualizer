/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:XmlVisualizer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace XmlVisualizer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<XmlTreeVM>();
            SimpleIoc.Default.Register<XmlDetailsVM>();
        }

        public static XmlDetailsVM XmlDetails
        {
            get { return ServiceLocator.Current.GetInstance<XmlDetailsVM>(); }
        }

        public static XmlTreeVM Tree
        {
            get { return ServiceLocator.Current.GetInstance<XmlTreeVM>(); }
        }

        public static MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
        
        public static void Cleanup()
        {
            XmlDetails.Cleanup();
            Tree.Cleanup();
            Main.Cleanup();
        }
    }
}