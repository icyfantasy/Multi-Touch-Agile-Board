using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StoryBoard
{   
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>

        private ObservableCollection<StoryInfo> story1 = new ObservableCollection<StoryInfo>();
        private ObservableCollection<StoryInfo> story2 = new ObservableCollection<StoryInfo>();

        public SurfaceWindow1()
        {
            InitializeComponent();
           
            // insert images for the library containers
            SetupLibraryContainerImages();

            //#region ConnectEventHandlers
            //SurfaceButtonAddImplicit.Click += new RoutedEventHandler(AddImplicit_Click);
            //SurfaceButtonAddExplicit.Click += new RoutedEventHandler(AddExplicit_Click);
            //#endregion

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        //#region AddImplicit
        //private void AddImplicit_Click(object sender, RoutedEventArgs e)
        //{
        //    Label L = new Label();
        //    // Set the content of the label.
        //    L.Content = "Item " + (MyScatterView.Items.Count + 1).ToString();
        //    // Add the label to the ScatterView control.
        //    // It is automatically wrapped in a ScatterViewItem control.
        //    MyScatterView.Items.Add(L);
        //}
        //#endregion

        //#region AddExplicit
        //private void AddExplicit_Click(object sender, RoutedEventArgs e)
        //{
        //    ScatterViewItem item = new ScatterViewItem();
        //    item.Content = "Item 180 Orientation";
        //    item.Orientation = 180.0;
        //    MyScatterView.Items.Add(item);
        //}
        //#endregion


        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void SetupLibraryContainerImages()
        {
            string[] groups = { "story1", "story2", "story3" };

            string imagesPath = @"\\engad.foe.auckland.ac.nz\engdfs\home\jlu233\Desktop\Frank\StoryBoard - Copy\StoryBoard\Resources\story\";

            story1.Add(new StoryInfo(imagesPath + "story10.jpg", "Task 1", "Story 1"));
            story1.Add(new StoryInfo(imagesPath + "story11.jpg", "Task 2", "Story 1"));
            story1.Add(new StoryInfo(imagesPath + "story12.jpg", "Task 3", "Story 1"));
            story1.Add(new StoryInfo(imagesPath + "story20.jpg", "Task 1", "Story 2"));
            story1.Add(new StoryInfo(imagesPath + "story21.jpg", "Task 2", "Story 2"));
            story1.Add(new StoryInfo(imagesPath + "story22.jpg", "Task 3", "Story 2"));


            ////create two lists of images
            //for (int i = 0; i <= 3; ++i)
            //{
            //    for (int groupName = 0; groupName < 3; ++groupName)
            //    {
            //        story1.Add(new StoryInfo("1",groups[groupName] + i.ToString("0") + ".jpg", groups[groupName]));                    
            //    }
            //}
            //for (int i = 4; i <= 9; ++i)
            //{
            //    for (int groupName = 0; groupName < 3; ++groupName)
            //    {
            //        story2.Add(new StoryInfo("2",groups[groupName] + i.ToString("0") + ".jpg", groups[groupName]));
            //    }
            //}

            //map the images to the first library container
            libraryContainer1.DataContext = "libraryContainer1";
            ICollectionView view1 = CollectionViewSource.GetDefaultView(story1);
            view1.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
            libraryContainer1.ItemsSource = view1;

            //map the images to the second library container
            libraryContainer2.DataContext = "libraryContainer2";
            ICollectionView view2 = CollectionViewSource.GetDefaultView(story2);
            view2.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
            libraryContainer2.ItemsSource = view2;
        }
    }
}