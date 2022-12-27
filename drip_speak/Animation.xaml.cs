// Decompiled with JetBrains decompiler
// Type: Encrypt.Animation
// Assembly: Encrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B0155084-1977-4D4E-A8CB-70DDE86B02BC
// Assembly location: C:\Users\Klonoa\Documents\Shared\drip_speak.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Encrypt
{
  public partial class Animation : UserControl, IComponentConnector
  {
    private int index;
    private DispatcherTimer timer;
    internal Image image;
    private bool _contentLoaded;

    public List<BitmapImage> Images { get; set; }

    public Animation() => this.InitializeComponent();

    public void Initiate()
    {
      if (this.Images == null)
        return;
      this.image.Source = (ImageSource) this.Images[this.index];
      this.timer = new DispatcherTimer(DispatcherPriority.Render);
      this.timer.Interval = TimeSpan.FromMilliseconds(80.0);
      this.timer.Tick += new EventHandler(this.updateImage);
      this.image.Visibility = Visibility.Hidden;
    }

    public void start()
    {
      this.image.Visibility = Visibility.Visible;
      this.timer.Start();
    }

    public void stop()
    {
      this.image.Visibility = Visibility.Hidden;
      this.timer.Stop();
      this.index = 0;
      this.image.Source = (ImageSource) this.Images[this.index];
    }

    private void updateImage(object sender, EventArgs e)
    {
      this.index = (this.index + 1) % this.Images.Count;
      this.image.Source = (ImageSource) this.Images[this.index];
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Encrypt;component/animation.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.image = (Image) target;
      else
        this._contentLoaded = true;
    }
  }
}
