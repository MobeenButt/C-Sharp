namespace Practice_2
{
    public class FileManager
    {
        public void SaveSongsToText(List<Song> songs, string filename)
        {
            using (FileStream file = new FileStream(filename, FileMode.Append))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        foreach (var song in songs)
                        {
                            writer.WriteLine($"{song.songID},{song.title},{song.artist},{song.duration},{song.genere},{song.isLiked},{song.playCount}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }
        public List<Song> LoadSongsFromText(string filename)
        {
            List<Song> list = new List<Song>();
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string line=reader.ReadLine();
                        while(line!=null)
                        {
                            var parts = line.Split(',');
                            if(parts.Length==7)
                            {
                                int songID=int.Parse(parts[0]);
                                string title=parts[1];
                                string artist=parts[2];
                                double duration=double.Parse(parts[3]);
                                string genere=parts[4];
                                bool isLiked=bool.Parse(parts[5]);
                                int playCount=int.Parse(parts[6]);
                                Song song=new Song(songID,title,artist,duration,genere,isLiked,playCount);
                                list.Add(song);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }
            return list;
        }
    }
}
