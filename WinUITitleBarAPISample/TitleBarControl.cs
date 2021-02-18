using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUITitleBarAPISample
{
    [ContentProperty(Name = "Content")]
    public sealed partial class TitleBarControl : Control
    {
        public TitleBarControl()
        {
            DefaultStyleKey = typeof(TitleBarControl);

            Loaded += (sender, args) =>
            {
                Window.SetTitleBar(AppTitleBar);

                Window.SizeChanged += Window_SizeChanged;
                Window.Activated += Window_Activated;
            };

            Unloaded += (sender, args) =>
            {
                Window.SizeChanged -= Window_SizeChanged;
                Window.Activated -= Window_Activated;
            };
        }

        private UIElement AppTitleBar { get; set; }
        private ContentPresenter ContentPresenter { get; set; }
        private Grid Grid { get; set; }
        private ContentPresenter InnerContentPresenter { get; set; }
        private ColumnDefinition LeftPaddingColumn { get; set; }
        private ColumnDefinition RightPaddingColumn { get; set; }

        public Brush AppTitleBarBackground { get => GetValue(AppTitleBarBackgroundProperty) as AcrylicBrush; set => SetValue(AppTitleBarBackgroundProperty, value); }
        public static readonly DependencyProperty AppTitleBarBackgroundProperty = DependencyProperty.Register(nameof(AppTitleBarBackground), typeof(AcrylicBrush), typeof(TitleBarControl), new PropertyMetadata(null));
        public object Content { get => GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(nameof(Content), typeof(object), typeof(TitleBarControl), new PropertyMetadata(null, (sender, args) =>
        {
            if (sender is TitleBarControl titleBarControl)
            {
                titleBarControl.ContentVisibility = args.NewValue is not null ? Visibility.Visible : Visibility.Collapsed;
            }
        }));
        public Visibility ContentVisibility { get => (Visibility)GetValue(ContentVisibilityProperty); set => SetValue(ContentVisibilityProperty, value); }
        public static readonly DependencyProperty ContentVisibilityProperty = DependencyProperty.Register(nameof(ContentVisibility), typeof(Visibility), typeof(TitleBarControl), new PropertyMetadata(Visibility.Collapsed));
        public object InnerContent { get => GetValue(InnerContentProperty); set => SetValue(InnerContentProperty, value); }
        public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register(nameof(InnerContent), typeof(object), typeof(TitleBarControl), new PropertyMetadata(null, (sender, args) =>
        {
            if (sender is TitleBarControl titleBarControl)
            {
                titleBarControl.InnerContentVisibility = args.NewValue is not null ? Visibility.Visible : Visibility.Collapsed;
            }
        }));
        public Visibility InnerContentVisibility { get => (Visibility)GetValue(InnerContentVisibilityProperty); set => SetValue(InnerContentVisibilityProperty, value); }
        public static readonly DependencyProperty InnerContentVisibilityProperty = DependencyProperty.Register(nameof(InnerContentVisibility), typeof(Visibility), typeof(TitleBarControl), new PropertyMetadata(Visibility.Collapsed));
        public string Title { get => GetValue(TitleProperty) as string; set => SetValue(TitleProperty, value); }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitleBarControl), new PropertyMetadata(null));
        public Window Window { get => GetValue(WindowProperty) as Window; set => SetValue(WindowProperty, value); }
        public static readonly DependencyProperty WindowProperty = DependencyProperty.Register(nameof(Window), typeof(Window), typeof(TitleBarControl), new(null));

        protected override void OnApplyTemplate()
        {
            AppTitleBar = (UIElement)GetTemplateChild(nameof(AppTitleBar));
            AppTitleBarBackground = (Brush)GetTemplateChild(nameof(AppTitleBarBackground));
            ContentPresenter = (ContentPresenter)GetTemplateChild(nameof(ContentPresenter));
            Grid = (Grid)GetTemplateChild(nameof(Grid));
            InnerContentPresenter = (ContentPresenter)GetTemplateChild(nameof(InnerContentPresenter));
            LeftPaddingColumn = (ColumnDefinition)GetTemplateChild(nameof(LeftPaddingColumn));
            RightPaddingColumn = (ColumnDefinition)GetTemplateChild(nameof(RightPaddingColumn));
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {

        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {

        }
    }
}