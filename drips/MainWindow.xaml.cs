// Decompiled with JetBrains decompiler
// Type: Encrypt.MainWindow
// Assembly: Encrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B0155084-1977-4D4E-A8CB-70DDE86B02BC
// Assembly location: C:\Users\Klonoa\Documents\Shared\drip_speak.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Encrypt
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private string[] bandCampCodes = new string[100]
    {
      "r3hx - yvwn",
      "adqs - u9de",
      "khr5 - b4wu",
      "kelb - xmcp",
      "u8sm - egs2",
      "mz4f - ubhc",
      "fypx - exqw",
      "wu9h - u5ys",
      "cmys - 5f2l",
      "crke - bpxj",
      "sx3g - wnay",
      "pcvz - cefr",
      "8sbz - xbel",
      "xfj6 - c59h",
      "h5bu - w3gv",
      "hrad - xsn9",
      "qlfe - js5z",
      "9cab - yd2g",
      "yhfm - blwu",
      "yqdf - xjcp",
      "384v - eys2",
      "aks7 - u3hc",
      "ryjd - 54qw",
      "d2gc - 7pys",
      "7nhw - ymdn",
      "vwe4 - 7zwe",
      "fj64 - 56l3",
      "mf3h - byqs",
      "faxj - wu6d",
      "w7q8 - wp9h",
      "cmr3 - crgv",
      "crmw - xdn9",
      "pxrq - jd5z",
      "8cmf - yc2g",
      "tsrv - bhwu",
      "j4mk - w57r",
      "6cbt - xrpl",
      "nhx3 - js7e",
      "lqc5 - kdpu",
      "q8hf - 6l3p",
      "bucl - yjdn",
      "5wjh - 76we",
      "bpgh - 5kl3",
      "a72s - 38qs",
      "r5le - cf6d",
      "drpg - wa9h",
      "7zql - eljw",
      "x384 - uets",
      "4vzh - e73l",
      "4ftj - 35lj",
      "4du8 - cu5y",
      "eh5y - cp7r",
      "gc7y - x2pl",
      "3swn - jd7e",
      "dqhm - kcpu",
      "pgc7 - 6h3p",
      "jx7j - vwaz",
      "64mr - gw3g",
      "kcr5 - b4du",
      "zjlb - xmsp",
      "n9sm - etc2",
      "mt4f - ub4c",
      "bkpx - ehjw",
      "w39h - u5ts",
      "cays - eu3l",
      "sfke - bplj",
      "sw3g - wf5y",
      "v7u4 - btjs",
      "7mwq - w79d",
      "xrj6 - ce6h",
      "4vbu - w38v",
      "4fad - hwu9",
      "qdfe - jsaz",
      "ghab - ys3g",
      "ycfm - bldu",
      "ypdf - xjsp",
      "294v - egc2",
      "ays7 - u34c",
      "xjha - 6weu",
      "j9cb - 642p",
      "72hw - yqwn",
      "mxe4 - 7zde",
      "fe64 - 5zx3",
      "mr3h - bgjs",
      "bmxj - wu9d",
      "wbq8 - c56h",
      "car3 - cr8v",
      "sfmw - xsu9",
      "pwrq - jdaz",
      "h7zq - 3axj",
      "hl26 - c7ay",
      "jsmk - w5fr",
      "9hbt - h3el",
      "ncx3 - jsfe",
      "lpc5 - kseu",
      "e9hf - 6l2p",
      "b3cl - ymwn",
      "axjh - 76de",
      "rqgh - 56x3",
      "ab2s - byjs"
    };
    private string missedCode = "";
    private const int ASCII_RANGE = 94;
    private const int ASCII_START = 32;
    private string cryptResult = "";
    private bool isEncoded;
    internal Animation loadingAnimation;
    internal TextBox codeInTextBox;
    internal Button cryptButton;
    private bool _contentLoaded;

    public MainWindow()
    {
      this.InitializeComponent();
      this.initLoadingAnimation();
    }

    private void initLoadingAnimation()
    {
      List<BitmapImage> bitmapImageList = new List<BitmapImage>();
      for (int index = 0; index < 47; ++index)
        bitmapImageList.Add(new BitmapImage(new Uri("pack://application:,,,/images/loading/loading" + string.Format("{0:D5}", (object) index) + ".png")));
      this.loadingAnimation.Images = bitmapImageList;
      this.loadingAnimation.Initiate();
    }

    private async void cryptButton_Click(object sender, RoutedEventArgs e)
    {
      this.loadingAnimation.start();
      this.cryptButton.Visibility = Visibility.Hidden;
      this.codeInTextBox.Visibility = Visibility.Hidden;
      await this.Crypt(this.codeInTextBox.Text);
      this.loadingAnimation.stop();
      this.codeInTextBox.Text = this.cryptResult;
      this.cryptResult = "";
      this.cryptButton.Visibility = Visibility.Visible;
      this.codeInTextBox.Visibility = Visibility.Visible;
    }

    private async Task Crypt(string code)
    {
      MainWindow mainWindow = this;
      Random rnd = new Random();
      await Task.Delay(5000 + rnd.Next(0, 5000));
      if (mainWindow.missedCode != "")
        code = mainWindow.missedCode;
      else if (rnd.Next(0, 10) == 0)
      {
        await Task.Delay(10000 + rnd.Next(0, 10000));
        mainWindow.codeInTextBox.Foreground = (Brush) Brushes.Red;
        mainWindow.codeInTextBox.IsReadOnly = true;
        int index = rnd.Next(0, mainWindow.bandCampCodes.Length - 1);
        mainWindow.cryptResult = mainWindow.bandCampCodes[index];
        mainWindow.missedCode = code;
        return;
      }
      mainWindow.codeInTextBox.IsReadOnly = false;
      mainWindow.codeInTextBox.Foreground = (Brush) Brushes.Black;
      mainWindow.missedCode = "";
      List<Func<string, string>> funcList = new List<Func<string, string>>()
      {
        new Func<string, string>(mainWindow.TransJunkLetters),
        new Func<string, string>(mainWindow.TransCharByPos),
        new Func<string, string>(mainWindow.TransOppositeLetters),
        new Func<string, string>(mainWindow.TransPalindrome),
        new Func<string, string>(mainWindow.TransFibSwap),
        new Func<string, string>(mainWindow.TransJunkLetters),
        new Func<string, string>(mainWindow.TransCharByPos)
      };
      int count = funcList.Count;
      string code1 = code;
      mainWindow.isEncoded = mainWindow.IsEncoded(code);
      string str;
      if (mainWindow.isEncoded)
      {
        str = mainWindow.RemoveSugar(code1);
        for (int index = 0; index < count; ++index)
          str = funcList[count - (index + 1)](str);
      }
      else
      {
        for (int index = 0; index < count; ++index)
          code1 = funcList[index](code1);
        str = mainWindow.AddSugar(code1);
      }
      mainWindow.cryptResult = str;
    }

    private string RemoveSugar(string code)
    {
      char[] charArray = code.ToCharArray();
      return new string(((IEnumerable<char>) charArray).Skip<char>(1).Take<char>(charArray.Length - 2).ToArray<char>());
    }

    private bool IsEncoded(string code)
    {
      if (code.Length < 2)
        return false;
      int num1 = (int) code[0];
      int num2 = (int) code[code.Length - 1];
      int num3 = this.AsciiSum(this.RemoveSugar(code)) % 94;
      int num4 = 32 + num3;
      return num1 == num4 && num2 == 126 - num3;
    }

    private string AddSugar(string code)
    {
      int num1 = this.AsciiSum(code) % 94;
      int num2 = 32 + num1;
      int num3 = 126 - num1;
      char ch = (char) num2;
      string str1 = ch.ToString();
      string str2 = code;
      ch = (char) num3;
      string str3 = ch.ToString();
      return str1 + str2 + str3;
    }

    private int AsciiSum(string code)
    {
      int num = 0;
      int length = code.Length;
      byte[] bytes = Encoding.ASCII.GetBytes(code.ToCharArray());
      for (int index = 0; index < length; ++index)
        num += (int) bytes[index];
      return num;
    }

    private string TransPalindrome(string code)
    {
      int length = code.Length;
      string str = "";
      for (int index = 0; index < length; ++index)
        str += code[length - (index + 1)].ToString();
      return str;
    }

    private string TransFibSwap(string code)
    {
      int length = code.Length;
      int index1 = 1;
      int index2 = 2;
      char[] charArray = code.ToCharArray();
      for (; index2 < length - 1; index2 += index1)
      {
        char ch = charArray[index1];
        charArray[index1] = charArray[index2];
        charArray[index2] = ch;
        index1 += index2;
      }
      return new string(charArray);
    }

    private string TransOppositeLetters(string code)
    {
      int length = code.Length;
      string str = "";
      for (int index = 0; index < length; ++index)
      {
        int num = 32 + ((int) code[index] - 32 + 47) % 94;
        str += ((char) num).ToString();
      }
      return str;
    }

    private string TransJunkLetters(string code)
    {
      Random random1 = new Random(code.Length > 0 ? (int) code[code.Length - 1] : 0);
      string str1 = code;
      if (this.isEncoded)
      {
        for (int index = 0; index < str1.Length - 1; ++index)
        {
          int num = (int) str1[index] % random1.Next(1, 5);
          str1 = str1.Substring(0, index + 1) + str1.Substring(index + 1 + num);
        }
      }
      else
      {
        Random random2 = new Random(code.Length > 0 ? (int) code[0] : 0);
        int num;
        for (int index1 = 0; index1 < str1.Length - 1; index1 = index1 + num + 1)
        {
          num = (int) str1[index1] % random1.Next(1, 5);
          string str2 = "";
          for (int index2 = 0; index2 < num; ++index2)
            str2 += ((char) random2.Next(32, 126)).ToString();
          str1 = str1.Substring(0, index1 + 1) + str2 + str1.Substring(index1 + 1);
        }
      }
      return str1;
    }

    private string TransCharByPos(string code)
    {
      string str = code.Length > 0 ? code[0].ToString() ?? "" : "";
      Random random = new Random(code.Length > 0 ? (int) code[0] : 0);
      if (this.isEncoded)
      {
        for (int index = 1; index < code.Length; ++index)
        {
          int num = (int) code[index];
          char ch = (char) (32 + ((int) code[index] - 32 + 94 - random.Next(0, 94)) % 94);
          str += ch.ToString();
        }
      }
      else
      {
        for (int index = 1; index < code.Length; ++index)
        {
          char ch = (char) (32 + (random.Next(0, 94) + (int) code[index] - 32) % 94);
          str += ch.ToString();
        }
      }
      return str;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Encrypt;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.loadingAnimation = (Animation) target;
          break;
        case 2:
          this.codeInTextBox = (TextBox) target;
          break;
        case 3:
          this.cryptButton = (Button) target;
          this.cryptButton.Click += new RoutedEventHandler(this.cryptButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
