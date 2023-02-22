using FMRookyScouter.Helper;
using FMRookyScouter.Interface;
using FMRookyScouter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace FMRookyScouter.Access
{
    public class DBAccess
    {
        #region Const Field
        public const string DB_PATH = @"DB\";
        public const string IMAGE_DB_PATH = @"ImageDB\";
        #endregion

        #region Properties
        public Dictionary<int, Sesson> Sessons { get; }
        public Dictionary<string, BitmapImage> Bitmaps { get; }
        #endregion

        #region Constructor
        public DBAccess()
        {
            if (!Directory.Exists(DB_PATH))
                throw new Exception("DB Path is empty");

            if (!Directory.Exists(IMAGE_DB_PATH))
                Directory.CreateDirectory(IMAGE_DB_PATH);

            Sessons = LoadSessions(DB_PATH);
            Bitmaps = LoadBitmaps(Sessons.Values);
        }
        #endregion

        #region Functions
        private static Dictionary<int, Sesson> LoadSessions(string dirPath)
        {
            var filePaths = Directory.GetFiles(DB_PATH);
            var sessons = new List<Sesson>();

            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                    continue;

                var doc = XDocument.Load(filePath);
                var sesson = new Sesson();

                sesson.Load(doc.Root);
                sessons.Add(sesson);
            }

            return sessons.ToDictionary(s => s.Year);
        }

        private static Dictionary<string, BitmapImage> LoadBitmaps(IEnumerable<Sesson> sessons)
        {
            var imagables = GetImagables(sessons);
            var dic = new Dictionary<string, BitmapImage>();

            foreach (var imagable in imagables)
            {
                var name = imagable.Name;
                var imageUrl = imagable.Image;

                if (dic.ContainsKey(name))
                    continue;
                if(!TryGetBitmap(name, imageUrl, out BitmapImage bitmap))
                    continue;

                dic.Add(name, bitmap);
            }

            return dic;
        }

        private static bool TryGetBitmap(string name, string url, out BitmapImage bitmap)
        {
            var file = Path.Combine(IMAGE_DB_PATH, name + ".png");

            if (BitmapHelper.TryLoad(file, out bitmap))
                return true;

            var ext = Path.GetExtension(url);
            if (!BitmapHelper.IsImageExtension(ext))
                return false;

            if (BitmapHelper.TryDownload("https:" + url, out bitmap))
                bitmap.Save(Path.Combine(IMAGE_DB_PATH, $"{name}{ext}"));

            return false;
        }

        private static List<IHasImage> GetImagables(IEnumerable<Sesson> sessons)
        {
            var imagables = new List<IHasImage>();
            var players = sessons.SelectMany(s => s.Players).ToList();

            foreach(var player in players)
            {
                if (IsValid(player.Club))
                    imagables.Add(player.Club);
                if (IsValid(player.Nation))
                    imagables.Add(player.Nation);
            }

            imagables = imagables.Distinct().ToList();

            return imagables;
        }

        private static bool IsValid(IHasImage imagable) => imagable.Image != null && imagable.Name != null;

        public Sesson GetSesson(int year)
        {
            if (!Sessons.TryGetValue(year, out Sesson sesson))
                return null;

            return sesson;
        }

        public List<Player> GetPlayers(int year)
        {
            return GetSesson(year)?.Players ?? new List<Player>();
        }

        public IDictionary<int, Player> GetPlayers(string name)
        {
            var dic = new Dictionary<int, Player>();

            foreach (var sesson in Sessons.Values)
            {
                var player = sesson.GetPlayer(name);
                if (player == null)
                    continue;

                dic.Add(sesson.Year, player);
            }

            return dic;
        }

        public Player GetPlayer(int year, string name)
        {
            return GetSesson(year)?.GetPlayer(name);
        }
        #endregion
    }
}
