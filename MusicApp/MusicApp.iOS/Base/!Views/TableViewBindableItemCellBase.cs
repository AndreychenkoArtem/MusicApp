using System;
using CoreGraphics;
using FlexiMvvm.Collections;
using Foundation;
using UIKit;

namespace MusicApp.iOS.Base
{
    public class TableViewBindableItemCellBase<TItemsContext, TItem> : TableViewBindableItemCell<TItemsContext, TItem>
        where TItemsContext : class
        where TItem : class
    {
        public TableViewBindableItemCellBase()
        {
            Initialize();
        }

        public TableViewBindableItemCellBase(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public TableViewBindableItemCellBase(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public TableViewBindableItemCellBase(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        public TableViewBindableItemCellBase(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        protected TableViewBindableItemCellBase(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal TableViewBindableItemCellBase(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        public virtual UIView View { get; set; }

        private void Initialize()
        {
            this.LoadView();
            if (this.View != null && this.View.Superview == null)
            {
                this.ContentView.AddSubview(this.View);
                this.View.TranslatesAutoresizingMaskIntoConstraints = false;
                NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[4]
                {
                    this.View.LeadingAnchor.ConstraintEqualTo((NSLayoutAnchor<NSLayoutXAxisAnchor>) this.ContentView.LeadingAnchor),
                    this.View.TopAnchor.ConstraintEqualTo((NSLayoutAnchor<NSLayoutYAxisAnchor>) this.ContentView.TopAnchor),
                    this.View.TrailingAnchor.ConstraintEqualTo((NSLayoutAnchor<NSLayoutXAxisAnchor>) this.ContentView.TrailingAnchor),
                    this.View.BottomAnchor.ConstraintEqualTo((NSLayoutAnchor<NSLayoutYAxisAnchor>) this.ContentView.BottomAnchor)
                });
            }
            this.ViewDidLoad();
        }

        public override void LoadView()
        {
            this.View = new UIView();
        }
    }
}