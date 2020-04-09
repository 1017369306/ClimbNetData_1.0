using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace PrismUICommon.CustomRegionAdapter
{
    /// <summary>
    /// DockingManager适配器类型 （用于注册类型和适配器之间的映射。prism原来只有在itemscontrol、selector和contentcontrol这三个实现了prism:RegionManager.RegionName=""可以把模块加载到控件）
    /// </summary>
    public class AvalonDockRegionAdapter : RegionAdapterBase<DockingManager>
    {
        #region Constructor
        public AvalonDockRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {
        }
        #endregion  //Constructor
        #region Overrides
        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            region.Views.CollectionChanged += delegate (
                Object sender, NotifyCollectionChangedEventArgs e)
            {
                this.OnViewsCollectionChanged_v2(sender, e, region, regionTarget);
            };

            regionTarget.DocumentClosed += delegate (
                            Object sender, DocumentClosedEventArgs e)
            {
                this.OnDocumentClosedEventArgs(sender, e, region);
            };
        }
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        #endregion  //Overrides

        #region Event Handlers

        /// <summary>
        /// Handles the NotifyCollectionChangedEventArgs event.原始版本
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (FrameworkElement item in e.NewItems)
                {
                    UIElement view = item as UIElement;

                    if (view != null)
                    {
                        //Create a new layout document to be included in the LayoutDocuemntPane (defined in xaml)
                        LayoutDocument newLayoutDocument = new LayoutDocument();
                        //Set the content of the LayoutDocument
                        newLayoutDocument.Content = item;

                        ViewModelBase viewModel = (ViewModelBase)item.DataContext;

                        if (viewModel != null)
                        {
                            //All my viewmodels have properties DisplayName and IconKey
                            newLayoutDocument.Title = viewModel.Title;
                            //GetImageUri is custom made method which gets the icon for the LayoutDocument
                            //newLayoutDocument.IconSource = this.GetImageUri(viewModel.IconKey);
                            newLayoutDocument.IconSource = viewModel.IconKey;
                            newLayoutDocument.CanClose = viewModel.CanClose;
                            newLayoutDocument.CanFloat = viewModel.CanFloat;
                            newLayoutDocument.CanMove = viewModel.CanMove;
                            newLayoutDocument.CanTogglePin = viewModel.CanTogglePin;
                        }

                        //Store all LayoutDocuments already pertaining to the LayoutDocumentPane (defined in xaml)
                        List<LayoutDocument> oldLayoutDocuments = new List<LayoutDocument>();
                        //Get the current ILayoutDocumentPane ... Depending on the arrangement of the views this can be either 
                        //a simple LayoutDocumentPane or a LayoutDocumentPaneGroup
                        ILayoutDocumentPane currentILayoutDocumentPane = (ILayoutDocumentPane)regionTarget.Layout.RootPanel.Children[0];

                        if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                        {
                            //If the current ILayoutDocumentPane turns out to be a group
                            //Get the children (LayoutDocuments) of the first pane
                            LayoutDocumentPane oldLayoutDocumentPane = (LayoutDocumentPane)currentILayoutDocumentPane.Children.ToList()[0];
                            foreach (LayoutDocument child in oldLayoutDocumentPane.Children)
                            {
                                oldLayoutDocuments.Insert(0, child);
                            }
                        }
                        else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                        {
                            //If the current ILayoutDocumentPane turns out to be a simple pane
                            //Get the children (LayoutDocuments) of the single existing pane.
                            foreach (LayoutDocument child in currentILayoutDocumentPane.Children)
                            {
                                oldLayoutDocuments.Insert(0, child);
                            }
                        }

                        //Create a new LayoutDocumentPane and inserts your new LayoutDocument
                        LayoutDocumentPane newLayoutDocumentPane = new LayoutDocumentPane();
                        newLayoutDocumentPane.InsertChildAt(0, newLayoutDocument);

                        //Append to the new LayoutDocumentPane the old LayoutDocuments
                        foreach (LayoutDocument doc in oldLayoutDocuments)
                        {
                            newLayoutDocumentPane.InsertChildAt(0, doc);
                        }

                        //Traverse the visual tree of the xaml and replace the LayoutDocumentPane (or LayoutDocumentPaneGroup) in xaml
                        //with your new LayoutDocumentPane (or LayoutDocumentPaneGroup)
                        if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                            regionTarget.Layout.RootPanel.ReplaceChildAt(0, newLayoutDocumentPane);
                        else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                        {
                            currentILayoutDocumentPane.ReplaceChild(currentILayoutDocumentPane.Children.ToList()[0], newLayoutDocumentPane);
                            regionTarget.Layout.RootPanel.ReplaceChildAt(0, currentILayoutDocumentPane);
                        }
                        newLayoutDocument.IsActive = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the NotifyCollectionChangedEventArgs event.版本2
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        void OnViewsCollectionChanged_v2(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (FrameworkElement item in e.NewItems)
                {
                    UIElement view = item as UIElement;

                    if (view != null)
                    {
                        //Create a new layout document to be included in the LayoutDocuemntPane (defined in xaml)
                        LayoutDocument newLayoutDocument = new LayoutDocument();
                        //Set the content of the LayoutDocument
                        newLayoutDocument.Content = item;

                        ViewModelBase viewModel = (ViewModelBase)item.DataContext;

                        if (viewModel != null)
                        {
                            //All my viewmodels have properties DisplayName and IconKey
                            newLayoutDocument.Title = viewModel.Title;
                            //GetImageUri is custom made method which gets the icon for the LayoutDocument
                            //newLayoutDocument.IconSource = this.GetImageUri(viewModel.IconKey);
                            newLayoutDocument.IconSource = viewModel.IconKey;
                            newLayoutDocument.CanClose = viewModel.CanClose;
                            newLayoutDocument.CanFloat = viewModel.CanFloat;
                            newLayoutDocument.CanMove = viewModel.CanMove;
                            newLayoutDocument.CanTogglePin = viewModel.CanTogglePin;
                        }
                        newLayoutDocument.IsActive = true;

                        //Store all LayoutDocuments already pertaining to the LayoutDocumentPane (defined in xaml)
                        List<LayoutDocument> oldLayoutDocuments = new List<LayoutDocument>();
                        //Get the current ILayoutDocumentPane ... Depending on the arrangement of the views this can be either 
                        //a simple LayoutDocumentPane or a LayoutDocumentPaneGroup
                        ILayoutDocumentPane currentILayoutDocumentPane = (ILayoutDocumentPane)regionTarget.Layout.RootPanel.Children[0];

                        if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                        {
                            //If the current ILayoutDocumentPane turns out to be a group
                            //Get the children (LayoutDocuments) of the first pane
                            LayoutDocumentPane oldLayoutDocumentPane = (LayoutDocumentPane)currentILayoutDocumentPane.Children.ToList()[0];
                            oldLayoutDocumentPane.Children.Add(newLayoutDocument);
                            //foreach (LayoutDocument child in oldLayoutDocumentPane.Children)
                            //{
                            //    oldLayoutDocuments.Insert(0, child);
                            //}
                        }
                        else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                        {
                            ((LayoutDocumentPane)currentILayoutDocumentPane).Children.Add(newLayoutDocument);
                            //If the current ILayoutDocumentPane turns out to be a simple pane
                            //Get the children (LayoutDocuments) of the single existing pane.
                            //foreach (LayoutDocument child in currentILayoutDocumentPane.Children)
                            //{
                            //    oldLayoutDocuments.Insert(0, child);
                            //}
                        }

                        //Create a new LayoutDocumentPane and inserts your new LayoutDocument
                        //LayoutDocumentPane newLayoutDocumentPane = new LayoutDocumentPane();
                        //newLayoutDocumentPane.InsertChildAt(0, newLayoutDocument);

                        //Append to the new LayoutDocumentPane the old LayoutDocuments
                        //foreach (LayoutDocument doc in oldLayoutDocuments)
                        //{
                        //    newLayoutDocumentPane.InsertChildAt(0, doc);
                        //}

                        //Traverse the visual tree of the xaml and replace the LayoutDocumentPane (or LayoutDocumentPaneGroup) in xaml
                        //with your new LayoutDocumentPane (or LayoutDocumentPaneGroup)
                        //if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPane))
                        //    regionTarget.Layout.RootPanel.ReplaceChildAt(0, newLayoutDocumentPane);
                        //else if (currentILayoutDocumentPane.GetType() == typeof(LayoutDocumentPaneGroup))
                        //{
                        //    currentILayoutDocumentPane.ReplaceChild(currentILayoutDocumentPane.Children.ToList()[0], newLayoutDocumentPane);
                        //    regionTarget.Layout.RootPanel.ReplaceChildAt(0, currentILayoutDocumentPane);
                        //}
                        //newLayoutDocument.IsActive = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the DocumentClosedEventArgs event raised by the DockingNanager when
        /// one of the LayoutContent it hosts is closed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event.</param>
        /// <param name="region">The region.</param>
        void OnDocumentClosedEventArgs(object sender, DocumentClosedEventArgs e, IRegion region)
        {
            try
            {
                region.Remove(e.Document.Content);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion 
    }
}
