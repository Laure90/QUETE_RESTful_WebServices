using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nancy.Hosting.Wcf;
using System.ServiceModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;

namespace QUETE_RESTful_WebServices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var userId = InputUserTextBox.Text;
            var Client = new WebClient();
            var url = String.Empty;          

            if (FilterNameComboBox.SelectedItem == postComboBox)
            {
                url = "posts?userId=" + userId;
                var text = Client.DownloadString($"https://jsonplaceholder.typicode.com/" + url);
                ICollection<Posts> post = JsonConvert.DeserializeObject<ICollection<Posts>>(text);
                foreach (Posts item in post)
                {
                    AnswerTextBox.Text = AnswerTextBox.Text + "userid = " + item.userId + "\n " + "id = " + item.id + "\n " + "title = " + item.title + "\n " + "body = " + item.body;
                }
            }
            else if (FilterNameComboBox.SelectedItem == commentComboBox)
            {
                url = "comments?postId=" + userId;
                var text = Client.DownloadString($"https://jsonplaceholder.typicode.com/" + url);
                ICollection<Comments> comments = JsonConvert.DeserializeObject<ICollection<Comments>>(text);
                foreach (Comments item in comments)
                {
                    AnswerTextBox.Text = AnswerTextBox.Text + "userid = " + item.userId + "\n " + "id = " + item.id + "\n " + "name = " + item.name + "\n " + "email = " + item.email + "\n " + "body = " + item.body;
                }
            }
            else if (FilterNameComboBox.SelectedItem == photoComboBox)
            {
                var text2 = Client.DownloadString($"https://jsonplaceholder.typicode.com/albums?userId=" + userId);
                ICollection<Albums> albums = JsonConvert.DeserializeObject<ICollection<Albums>>(text2);
                List<Photo> photos = new List<Photo>();

                foreach (Albums album in albums)
                {
                    var photo = Client.DownloadString($"https://jsonplaceholder.typicode.com/photos?albumId=" + album.id);
                    photos.AddRange(JsonConvert.DeserializeObject<ICollection<Photo>>(photo));

                }
                ICollection<Photo> photoCollection = photos;
                foreach (Photo photo in photoCollection)
                {
                    AnswerTextBox.Text = AnswerTextBox.Text + "AlbumId = " + photo.AlbumID + "\n " + "id = " + photo.Id + "\n " + "title = " + photo.Title + "\n " + "url = " + photo.Url + "\n " + "ThumbnailUrl = " + "\n " + photo.ThumbnailUrl;
                }
            }            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            InputUserTextBox.Text = String.Empty;
            AnswerTextBox.Text = String.Empty;
        }
    }
}
