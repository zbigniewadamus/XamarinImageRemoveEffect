using Lottie.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationTests
{
    public class ListObj
    {
        public string Key { get; set; }
        public string Image { get; set; }
    }
    public partial class MainPage : ContentPage
    {        
        public ListObj[] list { get; set; }
        private AnimationView explodeAnim = new AnimationView()
        {
            WidthRequest = 150,
            HeightRequest = 150,
            Margin = new Thickness(10,30,10,30),
            MaxFrame = 25,
            Scale = 2,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Speed = float.Parse("0.5"),
            AutoPlay = true,
            Animation = "https://assets4.lottiefiles.com/private_files/lf30_glegkhcn.json",
            AnimationSource = AnimationSource.Url
        };
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            fillTab();
            explodeAnim.OnFinishedAnimation += ClearAnimation;
        }

        private void fillTab()
        {
            List<ListObj> tmp = new List<ListObj>();
            tmp.Add(new ListObj() { Image = "https://i.picsum.photos/id/291/200/200.jpg?hmac=g1_gMJjGOhuKcjI43ybRbxQ8axXnS05ICBsEa4Lcaw0", Key = "Random 1" });
            tmp.Add(new ListObj() { Image = "https://i.picsum.photos/id/511/200/200.jpg?hmac=QTzrMGu9nrJDRE4TMoboI_EAM5ZdwXF09ylHr7LFZCg", Key = "Random 2" });
            tmp.Add(new ListObj() { Image = "https://i.picsum.photos/id/8/200/200.jpg?hmac=7z37E8o2M_U09oSFIN5CdqKXlYXuLeWxTHJVlT9UUlY", Key = "Random 3" });
            tmp.Add(new ListObj() { Image = "https://i.picsum.photos/id/730/200/200.jpg?hmac=wK_2ZX79XZRP1wVJ-dW_r-OkOjiz1kK8eHIyTw2Lr6s", Key = "Random 4" });
            tmp.Add(new ListObj() { Image = "https://i.picsum.photos/id/898/200/200.jpg?hmac=OJ_q58cXkhJJW-v5_I8OBbmtuEPORKBZ5hXG9PnO4QM", Key = "Random 5" });
            list = tmp.ToArray();
            OnPropertyChanged(nameof(list));
        }

        

        private void Restart(object sender, EventArgs e)
        {
            fillTab();
        }
        private void OnFinishAnim(object sender, EventArgs e)
        {
            var anim = sender as AnimationView;
            var grid = anim.Parent as Grid;            
            grid.Children.Remove(anim);
            
        }

        private void RemovePicture(object sender, EventArgs e)
        {
            var img = sender as Image;
            var grid = img.Parent as Grid;
            img.IsVisible = false;          
            grid.Children.Remove(img);
            grid.Children.Add(explodeAnim);
        }

        private void ClearAnimation(object sender, EventArgs e)
        {
            var anim = sender as AnimationView;
            var grid = anim.Parent as Grid;
            grid.Children.Remove(anim);
        }
    }
}
