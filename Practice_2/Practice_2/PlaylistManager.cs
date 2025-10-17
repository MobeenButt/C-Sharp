namespace Practice_2
{
    public class PlaylistManager
    {
        public List<Song> songs;
        public string PlaylistName;
        public int maxSongs;

        public void AddMultipleSongs(params Song[] songs)
        {
            foreach(var song in songs)
            {
                if(this.songs.Count<maxSongs)
                {
                    this.songs.Add(song);
                }
                else
                {
                    Console.WriteLine("Playlist is full. Cannot add more songs.");
                    break;
                }
            }
        }

        public void createPlaylist(string name,int maxSongs=10)
        {
            this.PlaylistName = name;
            this.maxSongs = maxSongs;
        }

        public List<Song>findSongsByGenre(string genre)
        {
            List<Song> genreSongs = new List<Song>();
            foreach (var value in genreSongs)
            {
                if(value.genere.Equals(genre, StringComparison.OrdinalIgnoreCase))
                {
                    genreSongs.Add(value);
                }
            }
            return genreSongs;
        }

        public void getPlaylistStatistics()
        {
            Console.WriteLine("Total Songs: ", songs.Count);
            double duration = 0;
            foreach (var song in songs)
            {
                duration = duration + song.duration;
            }
            double isLikedCount = 0;
            foreach(var song in songs)
            {
                if(song.isLiked==true)
                {
                    isLikedCount++;
                }
            }
            Console.WriteLine("Total Duration: ", duration);
            Console.WriteLine("Total Liked Songs: ", isLikedCount);
        }
    }
}
